using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Deck
    {
        public List<Card> Cards
        {
            get; private set;
        }

        public Deck(int numDecks)
        {
            Cards = CreateNewDeck(numDecks);
        }

        public void Shuffle()
        {
            List<Card> shuffledCards = new List<Card>();
            Random rand = new Random();

            while (Cards.Count > 0)
            {
                int index = rand.Next(0, Cards.Count - 1);
                shuffledCards.Add(Cards[index]);
                Cards.RemoveAt(index);
            }

            Cards = shuffledCards;
        }

        private List<Card> CreateNewDeck(int numDecks)
        {
            List<Card> deck = new List<Card>();

            for (int deckNum = 0; deckNum < numDecks; deckNum++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Value value in Enum.GetValues(typeof(Value)))
                    {
                        deck.Add(new Card(suit, value));
                    }
                }
            }

            return deck;
        }

        public enum Suit
        {
            Spades, Hearts, Diamonds, Clubs
        }

        public enum Value
        {
            Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }
    }
}
