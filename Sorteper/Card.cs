using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    class Card
    {
        public enum Color
        {
            Red,
            Black
        }
        public enum Suit
        {
            Spades,
            Hearts,
            Clubs,
            Diamonds

        }

        Suit suit;
        Color color;
        byte value;

        #region Props
        public Suit CardSuit { set { this.suit = value; } get { return this.suit; } }
        public Color CardColor { set { this.color = value; } get { return this.color; } }
        public byte CardValue { set { this.value = value; } get { return this.value; } }
        #endregion

        public Card(Suit suit, byte value)
        {
            this.CardSuit = suit;
            this.CardValue = value;
            if (suit == Suit.Clubs || suit == Suit.Spades)
            {
                this.color = Color.Black;
            }
            else
            {
                this.color = Color.Red;
            }

        }

        public override string ToString()
        {
            return this.value.ToString() + " of " + this.suit;
        }
    }
}
