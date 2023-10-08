using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Bear : Monster
    {
        internal Bear()
        {
            //Base stats
            Type = "Bear";
            Hp = 30;
            Dmg = 5;
            HitChance = 35;
        }
    }
}
