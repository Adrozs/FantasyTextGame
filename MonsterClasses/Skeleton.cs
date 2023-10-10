using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Skeleton : Monster
    {
        internal Skeleton()
        {
            //Base stats
            Type = "Skeleton";
            Level = 1;
            Hp = 45;
            HpMax = Hp;
            Dmg = 8;
            HitChance = 45;
        }
    }
}
