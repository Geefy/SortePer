using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    abstract class CardGame
    {
        List<Card> cards = new List<Card>();
        public List<Card> Cards { get { return cards; } }


        public byte CardAmount { get { return cardAmount; } set { cardAmount = value; } }
        public bool GameOver { get { return gameOver; } set { gameOver = value; } }

        byte cardAmount;
        bool gameOver = false;

        //Creates a standard 52 card deck
        public virtual void CreateDeck()
        {
            for (byte i = 0; i < this.CardAmount / 4; i++)
            {
                Cards.Add(new Card(Card.Suit.Clubs, (byte)(i + 1)));
                Cards.Add(new Card(Card.Suit.Diamonds, (byte)(i + 1)));
                Cards.Add(new Card(Card.Suit.Spades, (byte)(i + 1)));
                Cards.Add(new Card(Card.Suit.Hearts, (byte)(i + 1)));
            }
        }
        public abstract void Play(List<Player> players);

    }
}
