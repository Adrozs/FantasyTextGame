using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    public class Weapon
    {
        // Declare properties
        public string Name { get; set; }
        public int WeaponDmg { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }

        // When creating object, take input and use it to set the values
        public Weapon(string name, string type, int dmg, int price)
        {
            Name = name;
            WeaponDmg = dmg;
            Price = price;
            Type = type;
        }
    }
}
