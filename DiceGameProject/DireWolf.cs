using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class DireWolf : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();
        
        public DireWolf()
        {
            name = "Dire Wolf";
            description = "They're like dogs, but they want to kill you.";
            ResetStats();
        }
        public override void ResetStats()
        {
            health = d8.Roll() + 5;
            damage = d6.Roll() + 4;
            accuracy = 12 + d4.Roll();
            speed = 9;
            goldAmount = d20.Roll() + d12.Roll() + d8.Roll();
        }
    }
}
