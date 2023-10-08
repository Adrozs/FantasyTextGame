using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    static public class Misc
    {
        // Used to temporarily log users inputted choices
        public static int Choice {  get; set; }

        // Returns a random value between 0-100
        public static int Chance()
        {
            Random rnd = new Random();

            return rnd.Next(0, 100);
        }

        // Chooses randomly if there should be a battle. 65% chance for it to become a battle
        public static bool BattleChance() 
        {
            if (Chance() < 65)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
