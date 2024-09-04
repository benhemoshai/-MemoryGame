using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Logic
{
    public class Player
    {
        public string Name { get; }
        public bool IsComputer { get; set; }
        public int Score { get; private set; }

        public Player(string name, bool isComputer)
        {
            Score = 0;
            if (isComputer)
            {
                Name = "Computer";
                IsComputer = true;
            }
            else
            {
                Name = name;
                IsComputer = false;
            }
        }

        public void IncreaseScore()
        {
            Score++;
        }
    }

}
