using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Wisp : Monster
    {
        internal Wisp()
        {
            //Base stats
            Type = "Wisp";
            Hp = 25;
            Dmg = 2;
            HitChance = 90;
        }
    }
}
