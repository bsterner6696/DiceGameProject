using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Dragon : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();

        public Dragon()
        {
            name = "Dragon";
            description = "Holy shit, dragons! This must be endgame.";
            ResetStats();

        }
        public override void ResetStats()
        {
            health = d8.Roll() * 5;
            damage = d20.Roll() + d4.Roll() + d6.Roll() + d8.Roll() + d10.Roll() + d12.Roll();
            accuracy = 16 + d4.Roll();
            speed = 30;
            goldAmount = d20.Roll() * 20;
        }
    }
}
