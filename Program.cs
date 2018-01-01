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
            Primary.Start();

            while (Playing)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                if (choice == "quit" || choice == "QUIT")
                {
                    Playing = false;
                    Primary.Reset();
                }
                else if (choice == "help" || choice == "HELP")
                {
                    Console.Clear();
                    Primary.Help();
                }
                else if (choice == "look" || choice == "LOOK")
                {
                    Console.Clear();
                    Primary.Look();
                }
                else
                {
                    Primary.HandleInput(choice);
                }

            }
        }
    }
}