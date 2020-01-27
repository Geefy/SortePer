using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    public class GameManager
    {

        private Random rng = new Random();
        private CardGame cardGame;
        private List<Player> players = new List<Player>();

        public GameManager(int humanPlayerCount, int botCount)
        {
            for (int i = 1; i < humanPlayerCount+1; i++)
            {
                players.Add(new HumanPlayer("Player " + i));
            }
            for (int i = 0; i < botCount; i++)
            {
                players.Add(new CpuPlayer("Bot " + i));
            }
            cardGame = new SortePer();
        }

        //Only bots, testing purpose
        public GameManager(int botCount)
        {
            
            for (int i = 0; i < botCount; i++)
            {
                players.Add(new CpuPlayer("Bot " + i));
            }
            cardGame = new SortePer();
        }

        //Runs all the methods required for starting a card game
        public void Start()
        {
            Shuffle(cardGame.Cards);
            GiveCards();
            cardGame.Play(players);
        }

        //Fisher-Yates shuffle, randomizes the positions in the deck list
        public void Shuffle<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);
                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }
        //Gives out cards from the cardGame deck to the players playing until there are no more to give out
        void GiveCards()
        {
            while (cardGame.Cards.Count != 0)
            {
                foreach (Player player in players)
                {
                    if (cardGame.Cards.Count == 0)
                    {
                        return;
                    }
                    player.DrawFromDeck(cardGame.Cards.First());
                    cardGame.Cards.RemoveAt(0);
                    player.CheckMatches();
                
                }
            }
        }
    }
}
