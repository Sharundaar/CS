using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Creating a game with 3 doors");
            Game game = new Game(100);
            int counter = 0, nbTry = 10000;
            float probability;

            for (int i = 0; i < nbTry; ++i)
            {
                if (game.Play())
                    counter++;
            }

            probability = (float) counter / (float) nbTry;

            Console.Out.WriteLine("Probablity of opening the right door on " + nbTry + " try is " + probability);

                Console.In.ReadLine();
        }
    }
}
