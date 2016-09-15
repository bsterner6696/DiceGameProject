using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Ogre : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();

        public Ogre()
        {
            name = "Ogre";
            description = "It's been said these guys are like onions.";
            GetOgreStats();
        }
        public void GetOgreStats()
        {
            health = d8.Roll() + 10;
            damage = d12.Roll() + 4;
            accuracy = 13;
            speed = 5;
            goldAmount = d20.Roll() * 3;
        }

    }
}
