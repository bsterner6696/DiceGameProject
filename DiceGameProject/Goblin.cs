using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Goblin : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();
        public Goblin()
        {
            name = "Goblin";
            description = "A couple of common fart goblins.  Eat babies.";
            ResetStats();
        }
        public override void ResetStats()
        {
            health = d6.Roll() + 1;
            damage = d6.Roll();
            accuracy = 8 + d8.Roll();
            speed = 6 + d4.Roll();
            goldAmount = d8.Roll() * 3 ;
        }


    }
}
