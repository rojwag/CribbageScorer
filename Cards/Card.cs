using System;
using Suit = Cards.Deck.Suit;
using Value = Cards.Deck.Value;

namespace Cards
{
    public class Card
    {
        public Suit Suit
        {
            get; private set;
        }

        public Value Value
        {
            get; private set;
        }

        public int Number
        {
            get { return (int)Value + 1; }
        }

        public int Number10
        {
            get { return Number > 10 ? 10 : Number; }
        }

        // TODO: make internal
        public Card(Suit suit, Value value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Value, Suit);
        }

        public string ToStringShort()
        {
            string valueString = string.Empty;

            switch (Number)
            {
                case 1: valueString = "A"; break;
                case 11: valueString = "J"; break;
                case 12: valueString = "Q"; break;
                case 13: valueString = "K"; break;
                default: valueString = Number.ToString(); break;
            }

            valueString += Suit.ToString().Substring(0, 1);

            return valueString;
        }

        public bool Equals(Card c)
        {
            return this.Suit == c.Suit && this.Value == c.Value;
        }
    }
}
