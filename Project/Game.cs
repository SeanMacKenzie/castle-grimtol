using System;
using System.Collections.Generic;

namespace GrimtolIncorporated.Project
{
    public class Game : IGame
    {

        public Player CurrentPlayer { get; set; }
        public Room CurrentRoom { get; set; }

        Room gChambers = new Room("Mr. Grimtol's Chambers", " Tapestries depicting the Dark Lord and his recent triumphs and victories adorn the walls. On the bench next to the door is a small ornate dagger. The only exit is to the south.");
        Room hallway1 = new Room("2nd Floor Hallway", "A long, poorly lit hallway. At the end, to the south is a staircase that will lead to the lower floor. To the west is a storage closet and to the east is a door that reads 'Occupational Hypnotherapist.' The Dark Lord's chambers is to the north.");
        Room sCloset = new Room("The Supply Closet", "You know this room well. Many times you've come here, shut the door, and cried quietly. It's probably not a good idea to stay here.");
        Room hypno = new Room("Occupational Hypnotherapist Office", "Dr. Swanson is sitting at his desk, almost as if he's been waiting for you or any other low-level employee who might wander through his door. Before you can resist him, he counts to 3 and snaps his fingers.");
        Room bRoom = new Room("The Break Room", "");
        Room hallway2 = new Room("Hallway", "");
        Item dagger = new Item("Dagger", "A small ornate dagger. Might fetch a good price in town.");
        Item chocolates = new Item("Box of chocolates", "A big box of heart shaped chocolates. Might be Barb's favorite.");

        public void Setup()
        {
            gChambers.Exits.Add("South", hallway1);
            hallway1.Exits.Add("West", sCloset);
            hallway1.Exits.Add("East", hypno);
            hallway1.Exits.Add("South", hallway2);
            CurrentRoom = gChambers;
        }

        public void Reset()
        {
            Console.WriteLine("Not really sure about your decision to leave, you head back to the Dark Lord's chamber, ready to clean some floors.");
            
        }

        public void Start()
        {

            Console.WriteLine("Being a servant of the Dark Lord is no fun. When you signed up for the job, you thought, 'Hey, a paycheck's a paycheck. It won't all be fun and games but I've got to punch the clock somewhere.' You thought you'd get a good post, one with some of your friends burning villages or fighting Crusaders. Heck, even a guard post seems pretty glamorous right now. Never did you imagine you'd be scrubbing floors and emptying chamberpots. What would your mother say? Now, standing in the Dark Lord's Chambers, it's floor covered in all manner of mud and muck, a result of the Dark Lord's latest necromantic machinations, you realize you've made a terrible mistake and need to run away for good, maybe even join Usidore the Blue's quest to stop the Dark Lord. If at any time you change your mind and thing this is a bad idea, please enter 'quit' into your command line and you can go back to cleaning floors and empyting chamberpots. You look around room, trying to figure out if there's anything here you could take that might be worth something.");

            Console.WriteLine(gChambers.Description);
            CurrentRoom.Items.Add(dagger);

        }

        public void Look()
        {
            Console.WriteLine(CurrentRoom.Description);
        }

        public void HandleInput(string choice)
        {
            var input = choice.Split(' ');
            var command = input[0];
            var option = input[1];

            switch (command)
            {
                case "go":
                case "GO":
                    switch (option)
                    {
                        case "n":
                        case "north":
                        case "North":
                        case "NORTH":
                            Go("north");
                            break;
                        case "s":
                        case "south":
                        case "South":
                        case "SOUTH":
                            Go("south");
                            break;
                        case "w":
                        case "west":
                        case "West":
                        case "WEST":
                            Go("west");
                            break;
                        case "e":
                        case "east":
                        case "East":
                        case "EAST":
                            Go("east");
                            break;

                    }
                    break;
            }
        }

        public void LookItem(Item item)
        {
            Console.WriteLine(item.Description);
        }

        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Console.WriteLine(CurrentRoom.Description);
                if (CurrentRoom == hypno)
                {
                    Reset();
                }
            }
            else
            {
                Console.WriteLine("There's nothing in that direction for you to move to.");
            }
        }

        public void Take(Item item)
        {
            CurrentPlayer.Inventory.Add(item);
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}