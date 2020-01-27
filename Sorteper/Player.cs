using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    class Player
    {
        public List<Card> hand = new List<Card>();
        public string playerName;
        public bool isOut = false;
        public bool lost = false;

        public Player(string name)
        {
            playerName = name;
        }
        //Adds a card to the players hand
        public void DrawFromDeck(Card card)
        {
            hand.Add(card);
        }
        
        //First checks if players has any cards left
        //Draws a card from another player using user input to determine the index
        public virtual void DrawFromPlayer(Player player, int index)
        {
            if (hand.Count == 0)
            {
                Console.WriteLine(playerName + " has no cards left and is out of the game");
                isOut = true;
                return;
            }
            Console.WriteLine(playerName + " choose a card between 1 and " + player.hand.Count());
            index = UserInput();
            hand.Add(player.hand.ElementAt(index - 1));
            Console.WriteLine(this.playerName + " took " + player.hand.ElementAt(index - 1));
            player.hand.RemoveAt(index - 1);
        }


        //Yoink'd
        //Validates the user input, no pesky format exceptions
        public int UserInput()
        {
            bool valid = false;
            int value = 0;
            while (!valid)
            {
                if (Int32.TryParse(Console.ReadLine(), out value))
                {
                    valid = true;
                }
            }
            return value;
        }
        //Does a normal player turn including drawing, checking for matches and if player lost
        public void PlayerTurn(Player player)
        {
            //Checks if current players has 1 card left and if that card is sorte per then current players loses the game
            if (hand.Count == 1 && hand.First().CardValue == 10 && hand.First().CardSuit == Card.Suit.Spades)
            {
                
                Console.WriteLine(playerName + " lost the game");
                lost = true;
                return;
            }
            DrawFromPlayer(player, 0);
            CheckMatches();
        }

        //Checks if any cards in the players hand forms a pair, if matches are found they will be removed from the players hand
        public void CheckMatches()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                foreach (Card card in hand.ToList())
                {
                    if (card.CardValue == hand[i].CardValue && card.CardSuit != hand[i].CardSuit)
                    {
                        if (card.CardColor == hand[i].CardColor)
                        {
                            Console.WriteLine("Removed " + card.ToString());
                            Console.WriteLine("Removed " + hand[i].ToString());
                            hand.Remove(hand[i]);
                            hand.Remove(card);
                        }
                    }
                }
            }
        }
    }
}
