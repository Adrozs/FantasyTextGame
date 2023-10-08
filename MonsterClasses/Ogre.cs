using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Ogre : Monster
    {
        internal Ogre()
        {
            //Base stats
            Type = "Ogre";
            Hp = 70;
            Dmg = 12;
            HitChance = 50;
        }
    }
}
