using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Wolf : Monster
    {
        internal Wolf() : base()
        {
            // Wolfs base stats
            Type = "Wolf";
            Level = 1;
            Hp = 20;
            HpMax = Hp;
            Dmg = 2;
            HitChance = 40;
        } 
    }


    
}
