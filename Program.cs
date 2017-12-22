using System;
using GrimtolIncorporated.Project;

namespace GrimtolIncorporated
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Game Primary = new Game();

            // int Selection = 0;
            bool Playing = true;
            Primary.Setup();

            while (Playing)
            {
                Primary.Start();
                string choice = Console.ReadLine();
                if (choice == "quit" || choice == "QUIT")
                {
                    Playing = false;
                    Primary.Reset();
                }
                else if (choice == "help" || choice == "HELP")
                {

                }
                else
                {
                    Primary.HandleInput(choice);
                }

            }
        }
    }
}