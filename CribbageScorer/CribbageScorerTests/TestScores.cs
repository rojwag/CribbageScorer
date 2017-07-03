using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Card = Cards.Card;
using Suit = Cards.Deck.Suit;
using Value = Cards.Deck.Value;

namespace CribbageScorerTests
{
    [TestClass]
    public class TestScores
    {
        CribbageScorer.Scorer Scorer;

        [TestInitialize]
        public void Setup()
        {
            Scorer = new CribbageScorer.Scorer();
        }

        [TestMethod]
        public void Fifteens()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Five),
                new Card(Suit.Spades, Value.Four),
                new Card(Suit.Clubs, Value.Ten),
                new Card(Suit.Clubs, Value.Jack)
            };
            Card crib = new Card(Suit.Diamonds, Value.Ace);

            Assert.AreEqual(Scorer.Score(hand, crib), 4);
        }

        [TestMethod]
        public void RunOf3()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Eight),
                new Card(Suit.Spades, Value.Nine),
                new Card(Suit.Clubs, Value.Jack),
                new Card(Suit.Clubs, Value.Queen)
            };
            Card crib = new Card(Suit.Diamonds, Value.King);

            Assert.AreEqual(Scorer.Score(hand, crib), 3);
        }

        [TestMethod]
        public void RunOf4()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Eight),
                new Card(Suit.Spades, Value.Ten),
                new Card(Suit.Clubs, Value.Jack),
                new Card(Suit.Clubs, Value.Queen)
            };
            Card crib = new Card(Suit.Diamonds, Value.King);

            Assert.AreEqual(Scorer.Score(hand, crib), 4);
        }

        [TestMethod]
        public void RunOf5()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Nine),
                new Card(Suit.Spades, Value.Ten),
                new Card(Suit.Clubs, Value.Jack),
                new Card(Suit.Clubs, Value.Queen)
            };
            Card crib = new Card(Suit.Diamonds, Value.King);

            Assert.AreEqual(Scorer.Score(hand, crib), 5);
        }

        [TestMethod]
        public void DoubleRun()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Nine),
                new Card(Suit.Spades, Value.Ten),
                new Card(Suit.Clubs, Value.Ten),
                new Card(Suit.Clubs, Value.Jack)
            };
            Card crib = new Card(Suit.Diamonds, Value.King);

            Assert.AreEqual(Scorer.Score(hand, crib), 8);
        }

        [TestMethod]
        public void TripleRun()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Nine),
                new Card(Suit.Spades, Value.Ten),
                new Card(Suit.Clubs, Value.Ten),
                new Card(Suit.Clubs, Value.Ten)
            };
            Card crib = new Card(Suit.Diamonds, Value.Jack);

            Assert.AreEqual(Scorer.Score(hand, crib), 15);
        }

        [TestMethod]
        public void DoubleDoubleRun()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Nine),
                new Card(Suit.Spades, Value.Nine),
                new Card(Suit.Clubs, Value.Ten),
                new Card(Suit.Clubs, Value.Ten)
            };
            Card crib = new Card(Suit.Diamonds, Value.Jack);

            Assert.AreEqual(Scorer.Score(hand, crib), 16);
        }

        [TestMethod]
        public void DoubleRunOf4()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Nine),
                new Card(Suit.Spades, Value.Nine),
                new Card(Suit.Clubs, Value.Ten),
                new Card(Suit.Clubs, Value.Jack)
            };
            Card crib = new Card(Suit.Diamonds, Value.Queen);

            Assert.AreEqual(Scorer.Score(hand, crib), 16);
        }

        [TestMethod]
        public void PartialFlush()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Two),
                new Card(Suit.Clubs, Value.Four),
                new Card(Suit.Clubs, Value.Six),
                new Card(Suit.Clubs, Value.Eight)
            };
            Card crib = new Card(Suit.Diamonds, Value.Ten);

            Assert.AreEqual(Scorer.Score(hand, crib), 4);
        }

        [TestMethod]
        public void FullFlush()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Two),
                new Card(Suit.Clubs, Value.Four),
                new Card(Suit.Clubs, Value.Six),
                new Card(Suit.Clubs, Value.Eight)
            };
            Card crib = new Card(Suit.Clubs, Value.Ten);

            Assert.AreEqual(Scorer.Score(hand, crib), 5);
        }

        [TestMethod]
        public void RightJack()
        {
            List<Card> hand = new List<Card>
            {
                new Card(Suit.Clubs, Value.Two),
                new Card(Suit.Clubs, Value.Four),
                new Card(Suit.Clubs, Value.Six),
                new Card(Suit.Diamonds, Value.Jack)
            };
            Card crib = new Card(Suit.Diamonds, Value.Ten);

            Assert.AreEqual(Scorer.Score(hand, crib), 1);
        }
    }
}
