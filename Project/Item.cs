using System.Collections.Generic;

namespace GrimtolIncorporated.Project
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}