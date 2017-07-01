using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deck = Cards.Deck;
using Card = Cards.Card;

namespace CribbageScorer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck(1);
            deck.Shuffle();
            List<Card> hand = deck.Cards.GetRange(0, 4);
            Card crib = deck.Cards[4];

            var scorer = new Scorer();

            Console.WriteLine("Hand: {0}[{1}] Score: {2}", Deck.CardsToString(hand), crib.ToStringShort(), scorer.Score(hand, crib));
            Console.ReadKey();
        }
    }
}
