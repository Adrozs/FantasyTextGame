using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    internal class Wolf : Monster
    {
        internal Wolf()
        {
            // Wolfs base stats
            Type = "Wolf";
            Hp = 20;
            Dmg = 2;
            HitChance = 40;
        } 
    }


    
}
