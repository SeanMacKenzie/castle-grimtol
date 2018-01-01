using System;
using System.Collections.Generic;

namespace GrimtolIncorporated.Project
{
    public class Game : IGame
    {

        public Player CurrentPlayer { get; set; }
        public Room CurrentRoom { get; set; }


        Room gChambers = new Room("Mr. Grimtol's Chambers", " Tapestries depicting the Dark Lord and his recent triumphs and victories adorn the walls. On the bench next to the door is a small ornate dagger. The only exit is to the south.");
        Room hallway1 = new Room("2nd Floor Hallway", "A long, poorly lit hallway, the Dark Lord's banners hanging from the high ceiling. At the end, to the south is a staircase that will lead to the lower floor. To the west is a storage closet and to the east is a door that reads 'Occupational Hypnotherapist.' The Dark Lord's chambers is to the north.");
        Room sCloset = new Room("The Supply Closet", "You know this room well. Many times you've come here, shut the door, and cried quietly. It's probably not a good idea to stay here. Going ");
        Room hypno = new Room("Occupational Hypnotherapist Office", "Dr. Swanson is sitting at his desk, almost as if he's been waiting for you or any other low-level employee who might wander through his door. Before you can resist him, he counts to 3 and snaps his fingers.");
        Room bRoom = new Room("The Break Room", "Breakroom");
        Room hallway2 = new Room("Hallway", "Another long hallway, this one only slightly brighter because of the large open gate at the north end. 3 gruff men are standing guard just inside. To the east is the staff breakroom and to the west is the kitchen. Heading south will take you upstairs.");
        Room kitchen = new Room("Kitchen", "Kitchen");
        Room gateway = new Room("Gateway", "You recognize the 3 men guarding the gate immediately as Art, Chet, and Hank. They hate you. Doesn't look like you're going to get out this way very easily.");
        Item dagger = new Item("Dagger", "A small ornate dagger. Might fetch a good price in town.");
        Item chocolates = new Item("Box of chocolates", "A big box of heart shaped chocolates. Might be Barb's favorite.");

        public void Setup()
        {
            gChambers.Exits.Add("South", hallway1);
            hallway1.Exits.Add("West", sCloset);
            hallway1.Exits.Add("East", hypno);
            hallway1.Exits.Add("South", hallway2);
            hallway1.Exits.Add("North", gChambers);
            sCloset.Exits.Add("East", hallway1);
            hallway2.Exits.Add("South", hallway1);
            hallway2.Exits.Add("East", bRoom);
            hallway2.Exits.Add("West", kitchen);
            hallway2.Exits.Add("North", gateway);
            bRoom.Exits.Add("West", hallway2);
            kitchen.Exits.Add("East", hallway2);

            bRoom.Items.Add(chocolates);

            CurrentRoom = gChambers;
        }

        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Not really sure about your decision to leave, you head back to the Dark Lord's chamber, ready to clean some floors.");
            Console.ForegroundColor = ConsoleColor.Green;

        }

        public void Help()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please use 'keywords' while playing this game. Use words such as 'go,' 'look,' 'take,' and 'use' when interacting with the environment. Example: 'go north' will allow you to travel to the room to the north direction. 'Use potion' will spend the attributes of the potion item. 'Look' will give you a description of your surrounds. Hint: look at items to get a better idea of what they might do.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CurrentRoom.Description);
            Console.ForegroundColor = ConsoleColor.Green;


        }

        public void Start()
        {

            Console.WriteLine("Being a servant of the Dark Lord is no fun. When you signed up for the job, you thought, 'Hey, a paycheck's a paycheck. It won't all be fun and games but I've got to punch the clock somewhere.' You thought you'd get a good post, one with some of your friends burning villages or fighting Crusaders. Heck, even a guard post seems pretty glamorous right now. Never did you imagine you'd be scrubbing floors and emptying chamberpots. What would your mother say? Now, standing in the Dark Lord's Chambers, it's floor covered in all manner of mud and muck, a result of the Dark Lord's latest necromantic machinations, you realize you've made a terrible mistake and need to run away for good, maybe even join Usidore the Blue's quest to stop the Dark Lord. If at any time you change your mind and thing this is a bad idea, please enter 'quit' into your command line and you can go back to cleaning floors and empyting chamberpots. You look around room, trying to figure out if there's anything here you could take that might be worth something.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(gChambers.Description);
            Console.ForegroundColor = ConsoleColor.Green;
            CurrentRoom.Items.Add(dagger);

        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CurrentRoom.Description);
            Console.ForegroundColor = ConsoleColor.Green;
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
                            Go("North");
                            break;
                        case "s":
                        case "south":
                        case "South":
                        case "SOUTH":
                            Go("South");
                            break;
                        case "w":
                        case "west":
                        case "West":
                        case "WEST":
                            Go("West");
                            break;
                        case "e":
                        case "east":
                        case "East":
                        case "EAST":
                            Go("East");
                            break;

                    }
                    break;
                case "take":
                case "TAKE":
                    switch (option)
                    {
                        case "dagger":
                        case "DAGGER":
                            Take(dagger);
                            break;
                        case "chocolates":
                        case "CHOCOLATES":
                            Take(chocolates);
                            break;
                    }
                    break;
                case "use":
                case "USE":
                    break;
                case "look":
                case "LOOK":
                    switch(option) {
                        case "dagger":
                        case "DAGGER":
                            LookItem(dagger);
                            break;
                        case "chocolates":
                        case "CHOCOLATES":
                            LookItem(chocolates);
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
            Console.Clear();
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                Console.ForegroundColor = ConsoleColor.White;
                CurrentRoom = CurrentRoom.Exits[direction];
                Console.WriteLine(CurrentRoom.Description);
                Console.ForegroundColor = ConsoleColor.Green;
                if (CurrentRoom == hypno)
                {
                    Reset();
                    Start();

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
            Console.WriteLine($"You now have the {item}.");
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}