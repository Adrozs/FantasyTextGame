using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Goblin : Monster
    {
        internal Goblin()
        {
            //Base stats
            Type = "Goblin";
            Hp = 50;
            Level = 2;
            HpMax = Hp;
            Dmg = 12;
            HitChance = 50;
        }
    }
}
