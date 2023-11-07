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


        // Create all the Knight's swords as objects with their name, type, damage and price
        static Weapon Thornblade = new Weapon("Thornblade", "Sword", 1, 5);
        static Weapon Stormrender = new Weapon("Stormrender", "Sword", 2 ,13);
        static Weapon Frostfang = new Weapon("Frostbringer", "Sword", 3, 21);
        static Weapon Umbra = new Weapon("Umbra", "Sword", 4, 29);        
        static Weapon Goldbrand = new Weapon("Goldbrand", "Sword", 5,37);
        static Weapon Duskfang = new Weapon("Duskfang", "Sword", 6, 45);
        static Weapon Dawnbreaker = new Weapon("Dawnbreaker", "Sword", 7, 53);
        static Weapon Sunfire = new Weapon("Sunfire", "Sword", 8, 68);
        static Weapon Soulreaver = new Weapon("Soulreaver", "Sword", 9, 76);
        static Weapon Chillrend = new Weapon("Chillrend", "Sword", 10, 84);

        // Create a list of all swords
        static public List<Weapon> weaponList = new List<Weapon>() {
            Thornblade, Stormrender, Frostfang, Umbra, Goldbrand, Duskfang, Dawnbreaker, Sunfire, Soulreaver, Chillrend};

       
        public static Weapon ChooseRandomWeapon()
        {
            Random rnd = new Random();
            int weaponIndex = rnd.Next(0, Loot.weaponList.Count);

            return Loot.weaponList[weaponIndex];           
        }




    }
}
