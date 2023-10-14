using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    // Static as there's only gonna be one of the dictionaries, we're only using them to get reference
    static public class Loot
    {


        // need a method to see if anything should drop at all with chance()?
        // add 1 to hero.HealthPotions

        
        // Best is probably to do so weapons only can be purchased while in town at the smith
        


        // change hero.Weapon if weapon is better than current hero.WeaponDmg 


        // Create all the Knight's swords as objects with their name and damage
        static Sword Thornblade = new Sword("Thornblade", 1);
        static Sword Stormrender = new Sword("Stormrender", 2);
        static Sword Frostfang = new Sword("Frostbringer", 3);
        static Sword Umbra = new Sword("Umbra", 4);        
        static Sword Goldbrand = new Sword("Goldbrand", 5);
        static Sword Duskfang = new Sword("Duskfang", 6);
        static Sword Dawnbreaker = new Sword("Dawnbreaker", 7);
        static Sword Sunfire = new Sword("Sunfire", 8);
        static Sword Soulreaver = new Sword("Soulreaver", 9);
        static Sword Chillrend = new Sword("Chillrend", 10);

        // Create a list of swords
        static List<Sword> swords = new List<Sword>();

        // Constructor to initialize all the methods
        static Loot()
        {
            AddSwordsToList();
        }

        // Adds all swords to its list
        static void AddSwordsToList()
        {
            swords.Add(Thornblade);
            swords.Add(Stormrender);
            swords.Add(Frostfang);
            swords.Add(Umbra);
            swords.Add(Goldbrand);
            swords.Add(Duskfang);
            swords.Add(Dawnbreaker);
            swords.Add(Sunfire);
            swords.Add(Soulreaver);
            swords.Add(Chillrend);
        }





    }
}
