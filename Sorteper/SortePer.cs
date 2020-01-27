using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    class SortePer : CardGame
    {
        //Sets up the sorte per game by adding cards and removing 10 of clubs as stated in the rules
        public SortePer()
        {
            this.CardAmount = 52;
            CreateDeck();
            foreach (Card card in Cards.ToList())
            {
                if (card.CardSuit == Card.Suit.Clubs && card.CardValue == 10)
                {
                    this.Cards.Remove(card);
                }
            }
        }

        //Main game method, keeps looping until a loser is found.
        public override void Play(List<Player> players)
        {
            while (!GameOver)
            {
                int nextPlayer = 1;




                foreach (Player player in players.ToList())
                {
                    //checks if there is more than 1 player
                    if (nextPlayer >= players.Count)
                    {
                        nextPlayer = 0;
                    }

                    if (players[nextPlayer].hand.Count == 0)
                    {
                        players.Remove(players[nextPlayer]);
                    }
                    if (nextPlayer >= players.Count)
                    {
                        nextPlayer = 0;
                    }

                    //player turn
                    player.PlayerTurn(players[nextPlayer]);

                    //Checks if current players has lost, if true then game ends
                    if (players.Count <= 2)
                    {

                        if (player.lost)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player.playerName + " lost the game");
                            GameOver = true;
                            return;
                        }
                    }


                    //check if player is out of cards, if true player is removed from game
                    if (player.isOut)
                    {
                        players.Remove(player);
                    }

                    nextPlayer++;

                }



            }
        }


    }
}
