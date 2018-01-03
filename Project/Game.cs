using System;
using System.Collections.Generic;

namespace GrimtolIncorporated.Project
{
    public class Game : IGame
    {

        public Player CurrentPlayer { get; set; } = new Player();
        public Room CurrentRoom { get; set; }


        Room gChambers = new Room("Mr. Grimtol's Chambers", " Tapestries depicting the Dark Lord and his recent triumphs and victories adorn the walls. On the bench next to the door is a small ornate dagger. The only exit is to the south.");
        Room hallway1 = new Room("2nd Floor Hallway", "A long, poorly lit hallway, the Dark Lord's banners hanging from the high ceiling. At the end, to the south is a staircase that will lead to the lower floor. To the west is a storage closet and to the east is a door that reads 'Occupational Hypnotherapist.' The Dark Lord's chambers is to the north.");
        Room sCloset = new Room("The Supply Closet", "You know this room well. Many times you've come here, shut the door, and cried quietly. It's probably not a good idea to stay here. Turning around and going east will take you back to the hallway.");
        Room hypno = new Room("Occupational Hypnotherapist Office", "Dr. Swanson is sitting at his desk, almost as if he's been waiting for you or any other low-level employee who might wander through his door. Before you can resist him, he counts to 3 and snaps his fingers.");
        Room bRoom = new Room("The Break Room", "There are several long tables in this room. A few guards are eating their breakfast and a few other servants are cleaning or making coffee. Seated at one table is an old friend, Doug. You know from previous conversations that he hates his job too and is looking to leave. On top of the table in front of Doug is a box of chocolates. Turning around and heading west will take you back out to the main hallway.");
        Room hallway2 = new Room("Main Hallway", "Another long hallway, this one only slightly brighter than the one upstairs because of the large open gate at the north end. 3 gruff men are standing guard just inside. To the east is the staff breakroom and to the west is the kitchen. Heading south will take you upstairs.");
        Room kitchen = new Room("Kitchen", "5 cooks are already preparing a grand meal the Dark Lord will share with his generals this evening. One cook you recognize from employee orientation is Barbara. From what you can remember, she seems to be extremely loyal to the Dark Lord. You even think she might have a crush on the aged Necromancer. She also likes something she called 'Grey's' and talks about it incessantly during every break you have shared with her. Directly behind her to the west is a small door that leads outside. Heading east will take you back into the main hallway.");
        Room gateway = new Room("Gateway", "You recognize the 3 men guarding the gate immediately as Art, Chet, and Hank. They hate you. Doesn't look like you're going to get out this way very easily. You can turn back and head south to the main hallway.");
        Room doorway = new Room("Doorway", "As you walk towards the door, Barb recognizes you and immediately starts talking. It doesn't seem like she's going to let up any time soon either. She's talking about how dreamy the Dark Lord's eyes are when you realize you need to do something to get out of this situation. You can turn back and head east to enter the central part of the kitchen.");
        Item dagger = new Item("dagger", "A small ornate dagger. Might fetch a good price in town.");
        Item chocolates = new Item("box of chocolates", "A big box of heart shaped chocolates. I think I remember Barb saying these were her favorite.");
        Item doug = new Item("Doug", "He's an old pal from your schooldays and looking to leave the service of the Dark Lord too.");


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
            gateway.Exits.Add("South", hallway2);
            bRoom.Exits.Add("West", hallway2);
            kitchen.Exits.Add("East", hallway2);
            kitchen.Exits.Add("West", doorway);

            bRoom.Items.Add(chocolates);
            bRoom.Items.Add(doug);
            gChambers.Items.Add(dagger);

            CurrentRoom = gChambers;
        }

        public void Reset()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Thank you for playing.");
            Console.ForegroundColor = ConsoleColor.Green;

        }

        public void PlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Not really sure about your decision to leave, you head back to the Dark Lord's chamber, ready to clean some floors.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Would you like to play again? If so, please type 'yes'. If not, please type 'quit'.");
            CurrentRoom = gChambers;
        }

        public void Dead()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Would you like to play again? If so, please type 'yes'. If not, please type 'quit'.");
            CurrentRoom = gChambers;
        }

        public void Victory()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You've successfully escaped the service of the Dark Lord. Great job. Would you like to play again, maybe try to find a different solution and a different ending to this game? If so, please type 'yes'. If not, please type 'quit'.");
        }

        public void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Please use keywords while playing this game. Use words such as 'go,' 'look,' 'take,' and 'use' when interacting with the environment. Example: 'go north' will allow you to travel to the room to the north direction. 'Use potion' will spend the attributes of the potion item. 'Look' will give you a description of your surrounds. Hint: look at items to get a better idea of what they might do.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CurrentRoom.Description);
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Inventory()
        {
            for (int i = 0; i < CurrentPlayer.Inventory.Count; i++)
            {
                Console.WriteLine($"{CurrentPlayer.Inventory[i].Name}");
            }
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("GRIMTOL INCORPORATED. Being a servant of the Dark Lord is no fun. When you signed up for the job, you thought, 'Hey, a paycheck's a paycheck. It won't all be fun and games but I've got to punch the clock somewhere.' You thought you'd get a good post, one with some of your friends burning villages or fighting Crusaders. Heck, even a guard post seems pretty glamorous right now. Never did you imagine you'd be scrubbing floors and emptying chamberpots. What would your mother say? Now, standing in the Dark Lord's Chambers, it's floor covered in all manner of mud and muck, a result of the Dark Lord's latest necromantic machinations, you realize you've made a terrible mistake and need to run away for good, maybe even join Usidore the Blue's quest to stop the Dark Lord. If at any time you change your mind and think this is a bad idea, please enter 'quit' into your command line and you can go back to cleaning floors and empyting chamberpots. You look around room, trying to figure out if there's anything here you could take that might be worth something.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(gChambers.Description);
            Console.ForegroundColor = ConsoleColor.Green;


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
                        default:
                            Go("null");
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
                        case "doug":
                        case "DOUG":
                            Take(doug);
                            break;
                        default:
                            Console.WriteLine("That's not an item you can take.");
                            break;
                    }
                    break;
                case "use":
                case "USE":
                    switch (option)
                    {
                        case "dagger":
                        case "DAGGER":
                            UseItem("dagger");
                            break;
                        case "chocolates":
                        case "CHOCOLATES":
                            UseItem("chocolates");
                            break;
                        case "doug":
                        case "DOUG":
                            UseItem("doug");
                            break;
                        default:
                            Console.WriteLine("That's not an item you can use.");
                            break;
                    }
                    break;
                case "look":
                case "LOOK":
                    switch (option)
                    {
                        case "dagger":
                        case "DAGGER":
                            LookItem(dagger);
                            break;
                        case "chocolates":
                        case "CHOCOLATES":
                            LookItem(chocolates);
                            break;
                        case "doug":
                        case "DOUG":
                            LookItem(doug);
                            break;
                        default:
                            Console.WriteLine("That's not an item.");
                            break;
                    }
                    break;
            }
        }

        public void LookItem(Item item)
        {
            if (CurrentPlayer.Inventory.Contains(item))
            {
                Console.WriteLine(item.Description);
            }
            else
            {
                Console.WriteLine("That's not an item you possess.");
            }
        }

        public void Go(string direction)
        {

            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                CurrentRoom = CurrentRoom.Exits[direction];
                Console.WriteLine(CurrentRoom.Name);
                Console.WriteLine(CurrentRoom.Description);
                Console.ForegroundColor = ConsoleColor.Green;
                if (CurrentRoom == hypno)
                {
                    PlayAgain();

                }
            }
            else
            {
                Console.WriteLine("There's nothing in that direction for you to move to.");
            }
        }

        public void Take(Item item)
        {
            if (CurrentRoom.Items.Contains(item))
            {
                CurrentPlayer.Inventory.Add(item);
                Console.WriteLine($"You now have the {item.Name}.");
            }
            else
            {
                Console.WriteLine("You can't do that.");
            }
        }

        public void UseItem(string itemName)
        {
            if (itemName == "dagger" && CurrentPlayer.Inventory.Contains(dagger) && CurrentPlayer.Inventory.Contains(doug) && CurrentRoom == gateway)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You pull the dagger from your pocket and start swinging it around wildy. Hank raises his maul into the air and brings it down on your head, ending you life and your futile plan to escape. Doug raises his arms in the air and let's everyone know he had no part in this.");
                Dead();
            }
            else if (itemName == "dagger" && CurrentRoom == gateway && CurrentPlayer.Inventory.Contains(dagger))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You pull the dagger from your pocket and start swinging it around wildy. Hank raises his maul into the air and brings it down on your head, ending you life and your futile plan to escape.");
                Dead();
            }
            else if (itemName == "dagger" && CurrentPlayer.Inventory.Contains(dagger) && CurrentPlayer.Inventory.Contains(doug) && CurrentRoom == doorway)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A look of sheer terror comes over Barb's eyes as you pull the dagger from your pocket. Another nearby cook let's out a yelp and raises the butcher knife in his hand when he realizes Barb is in danger. You stab at Barbara just as the nearby cook's blade slices your throat and your body falls to the floor. Doug raises his arms in the air and let's everyone know he had no part in this.");
                Dead();
            }
            else if (itemName == "dagger" && CurrentPlayer.Inventory.Contains(dagger) && CurrentRoom == doorway)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A look of sheer terror comes over Barb's eyes as you pull the dagger from your pocket. Another nearby cook let's out a yelp and raises the butcher knife in his hand when he realizes Barb is in danger. You stab at Barbara just as the nearby cook's blade slices your throat and your body falls to the floor.");
                Dead();
            }
            else if (itemName == "dagger" && CurrentPlayer.Inventory.Contains(dagger))
            {
                Console.WriteLine("The dagger is of no use here.");
            }
            else if (itemName == "chocolates" && CurrentPlayer.Inventory.Contains(chocolates) && CurrentPlayer.Inventory.Contains(doug) && CurrentRoom == doorway)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Barb seems overjoyed that you would give such a beautiful gift as these chocolates. Her eyes immediately swell will tears and as she reaches for something to dry her eyes, you and Doug slip out the door, leaving the service of the Dark Lord behind you forever.");
                Victory();
            }
            else if (itemName == "chocolates" && CurrentPlayer.Inventory.Contains(chocolates) && CurrentRoom == doorway)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Barb seems overjoyed that you would give such a beautiful gift as these chocolates. Her eyes immediately swell will tears and as she reaches for something to dry her eyes, you slip out the back door, leaving the service of the Dark Lord behind you forever.");
                Victory();
            }
            else if (itemName == "chocolates" && CurrentPlayer.Inventory.Contains(chocolates) && CurrentRoom == gateway)
            {

                Console.WriteLine("The three guards look at you funny as you try to give them the box of chocolates. Chet slaps the box out of your hands and tells you to get back to work.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(CurrentRoom.Description);
            }
            else if (itemName == "chocolates" && CurrentPlayer.Inventory.Contains(chocolates))
            {
                Console.WriteLine("The box of chocolates is of no use here.");
            }
            else if (itemName == "doug" && CurrentPlayer.Inventory.Contains(doug) && CurrentRoom == gateway)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You forcefully push Doug into the group of guards. You explain to them that Doug was trying to leave the Dark Lord's service and sell his secrets to Usidore the Blue. Hank mentions that he'll be tried for treason and as they lead him off, they don't notice that you've slipped past them through the doorway. You make your way to the side of the fortress and into the woods, leaving the life of scrubbing floors and emptying chamberpots behind you.");
                Victory();
            }
            else if (itemName == "doug" && CurrentPlayer.Inventory.Contains(doug))
            {
                Console.WriteLine("Doug is of no use here.");
            }
            else
            {
                Console.WriteLine("I'm not entirely sure what you want to do. Please try again.");
            }

        }
    }
}