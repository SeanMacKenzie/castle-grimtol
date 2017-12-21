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
            string Input = "";
            int Selection = 0;
            bool Playing = true;
            
            while (Playing)
            {
                Primary.Setup();
                Input = Console.ReadLine();
                if (Input == "quit")
                {
                    Playing = false;
                    Primary.Reset();
                }
                else if (Input == "north")
                {
                    
                }

            }
        }
    }
}
