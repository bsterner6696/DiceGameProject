using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Monster : Fighter
    {

        D20 d20 = new D20();
        
        public Monster()
        {
            firstOrSecond = 2;
        }

        public override void SetName()
        {
            name = (name + " " + firstOrSecond);
        }
        public override void PickTarget()
        {
            if (d20.Roll() > 10)
            {
                target = 3;

            }
            else
            {
                target = 4;

            }

        }

    }
}
