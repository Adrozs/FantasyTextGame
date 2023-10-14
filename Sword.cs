using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    public class Sword
    {
        // Declare properties
        public string Name { get; set; }
        public int WeaponDmg { get; set; }

        // When creating object, take input and use it to set the values
        public Sword(string name, int dmg)
        {
            Name = name;
            WeaponDmg = dmg;
        }

    }
}
