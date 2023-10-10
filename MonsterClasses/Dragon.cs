using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Dragon : Monster
    {
        internal Dragon()
        {
            //Base stats
            Type = "Dragon";
            Hp = 100;
            Level = 4;
            HpMax = Hp;
            Dmg = 25;
            HitChance = 80;
        }
    }
}
