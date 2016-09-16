using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class RockTroll : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();

        public RockTroll()
        {
            name = "Rock Troll";
            description = "These monsters eat rocks.  That's nuts.";
            ResetStats();
        }
        public override void ResetStats()
        {
            health = 20;
            damage = d12.Roll() * 2;
            accuracy = 12 + d4.Roll();
            speed = 6;
            goldAmount = 30 + d20.Roll();
        }
    }
}
