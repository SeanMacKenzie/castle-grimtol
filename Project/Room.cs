using System.Collections.Generic;

namespace GrimtolIncorporated.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Dictionary<string, Room> Exits { get; set; } = new Dictionary<string, Room>();


        public void UseItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // public void AddExit(string direction, Room room)
        // {
        //     if (!Exits.ContainsKey(direction))
        //     {
                
        //     }

        // }
    }
}