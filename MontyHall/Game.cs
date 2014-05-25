using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall
{
    class Game
    {
        public Game(int nbDoor)
        {
            Doors = new bool[nbDoor];
            generator = new Random();
        }

        public void Initialize()
        {
            int door = generator.Next(0, Doors.Length);

            for (int i = 0; i < Doors.Length; ++i)
            {
                Doors[i] = false;
            }

            Doors[door] = true;
            car = door;

        }

        public void ChooseDoorFirstTime(int door)
        {
            if (door < Doors.Length)
            {
                choice = door;
                
                // If there is a car under the choosen door
                if (Doors[choice] == true)
                {
                    int hide = generator.Next(0, Doors.Length);
                    
                    // If we have a bad random
                    if (hide == choice)
                    {
                        // Just take the door next to the one we choose
                        hide++;
                        if (hide == Doors.Length)
                            hide -= 2;

                        hidden = hide;
                    }

                }
                else // No car
                {
                    hidden = car;
                }
            }
        }

        public bool ChooseDoorSecondTime(bool stayOrSwitch) {
            if (stayOrSwitch)
            {
                return Doors[hidden];
            }
            else
            {
                return Doors[choice];
            }
        }

        public bool Play()
        {
            bool result;

            Console.Out.WriteLine("Initializing a party");
            Initialize();
            Console.Out.WriteLine("Opening the first door");
            this.ChooseDoorFirstTime(0);
            Console.Out.WriteLine("Switch choice");
            // Send true to switch choice and false to keep
            result = ChooseDoorSecondTime(true);

            return result;
        }

        int choice;
        int car;
        int hidden;

        public bool[] Doors { get; set; }

        private Random generator;
    }
}
