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
            Hp = 45;
            Dmg = 8;
            HitChance = 45;
        }
    }
}
