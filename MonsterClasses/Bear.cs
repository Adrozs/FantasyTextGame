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
            Level = 1;
            Hp = 30;
            HpMax = Hp;
            Dmg = 5;
            HitChance = 35;
        }
    }
}
