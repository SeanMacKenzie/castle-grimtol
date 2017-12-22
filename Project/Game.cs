using System;
using System.Collections.Generic;

namespace GrimtolIncorporated.Project
{
    public class Game : IGame
    {

        public Player CurrentPlayer { get; set; }
        public Room CurrentRoom { get; set; }

        Room gChambers = new Room("Mr. Grimtol's Chambers", "Tapestries depicting the Dark Lord and his recent triumphs and victories adorn the walls. On the bench next to the door is a small ornate dagger. The only exit is to the south.");
        Room hallway1 = new Room("Hallway", "");
        Room bRoom = new Room("The Break Room", "");
        Room sCloset = new Room("The Supply Closet", "");
        Room hallway2 = new Room("Hallway", "");

        public void Setup()
        {

            Item dagger = new Item("Dagger", "A small ornate dagger. Might fetch a good price in town.");
            Item chocolates = new Item("Box of chocolates", "A big box of heart shaped chocolates. Might be Barb's favorite.");

            gChambers.Exits.Add("South", hallway1);
            hallway1.Exits.Add("West", sCloset);
            hallway1.Exits.Add("South", hallway2);

        }

        public void Reset()
        {
            Console.WriteLine("Not really sure about your decision to leave, you head back to the Dark Lord's chamber, ready to clean some floors.");
            CurrentRoom = gChambers;
        }

        public void Start()
        {
            CurrentRoom = gChambers;
            Console.Write(@"Being the servant of the Dark Lord is no fun. When you signed up for the job, you thought, 'Hey, a paycheck's a paycheck. It won't all be fun and games but I've got to punch the clock somewhere.' You thought you'd get a good post, one with some of your friends burning villages or fighting Crusaders. Heck, even a guard post seems pretty glamorous right now. Never did you imagine you'd be scrubbing floors and emptying chamberpots. What would your mother say? Now, standing in the Dark Lord's Chambers, it's floor covered in all manner of mud and muck, a result of the Dark Lord's latest necromantic machinations, you realize you've made a terrible mistake and need to run away for good, maybe even join Usidore the Blue's quest to stop the Dark Lord. If at any time you change your mind and thing this is a bad idea, please enter 'quit' into your command line and you can go back to cleaning floors and empyting chamberpots. You look around room, trying to figure out if there's anything here you could take that might be worth something.");
            Console.WriteLine(gChambers.Description);
            gChambers.Items.Add(dagger);
        }

        public void Look()
        {
            Console.WriteLine(CurrentRoom.Description);
        }

        public void LookItem(Item item)
        {
            Console.WriteLine(item.Description);
        }

        public void Go(string direction)
        {
            CurrentRoom.Exits[direction] = CurrentRoom;
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