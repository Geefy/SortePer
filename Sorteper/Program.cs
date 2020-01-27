using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager(13);
            game.Start();


            Console.Read();
        }
    }
}
