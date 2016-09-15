using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Gremlin : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();
        public Gremlin()
        {
            name = "Gremlin";
            flavorText = "A crusty little gremlin.";
            GetGremlinStats();
        }
       
        public void GetGremlinStats()
        {
            health = d4.Roll() + 1;
            damage = d4.Roll();
            accuracy = 6 + d10.Roll();
            speed = 4 + d6.Roll();
            goldAmount = d12.Roll();
        }
        
    }
}
