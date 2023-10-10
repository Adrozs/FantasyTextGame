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
            Level = 2;
            Hp = 70;
            HpMax = Hp;
            Dmg = 12;
            HitChance = 50;
        }
    }
}
