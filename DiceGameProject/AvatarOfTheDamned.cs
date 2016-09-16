using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class AvatarOfTheDamned: Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();

        public AvatarOfTheDamned()
        {
            name = "Avatar of the Damned";
            description = "Some scary looking monster things.  Their name sounds a lot cooler than they actually are.";
            ResetStats();
        }
        public override void ResetStats()
        {
            health = d4.Roll() * 5;
            damage = d4.Roll() + d6.Roll() + d8.Roll() + d10.Roll() + d12.Roll();
            accuracy = d4.Roll() * 5;
            speed = d8.Roll() * 3;
            goldAmount = d20.Roll() * 5 + d10.Roll() * 10;
        }
    }
}
