using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        
        public Player CurrentPlayer { get; set; }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup()
        {
            throw new System.NotImplementedException();
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}