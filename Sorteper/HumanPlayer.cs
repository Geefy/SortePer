using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name)
        {
        }
        //First checks if players has any cards left
        //Draws a card from another player using user input to determine the index
        public override void DrawFromPlayer(Player player, int index)
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
            player.hand.RemoveAt(index - 1);

        }
    }
}
