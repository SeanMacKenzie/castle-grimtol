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
                else if (choice == "yes" || choice == "YES")
                {
                    Primary.Start();
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
                else if (choice.Contains("look") || choice.Contains("take") || choice.Contains("use") || choice.Contains("go") || choice.Contains("LOOK") || choice.Contains("TAKE") || choice.Contains("USE") || choice.Contains("GO"))
                {
                    Primary.HandleInput(choice);
                }
                else
                {
                    Console.WriteLine("I'm sorry, I don't know what you're trying to do. Please enter another command. Thanks.");
                }

            }
        }
    }
}