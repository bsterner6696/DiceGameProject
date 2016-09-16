using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer()
        {
            name = "computer player";
        }
        D4 d4 = new D4();
        public override void PickTarget()
        {
            if (d4.Roll() > 2)
            {
                target = 1;
                Console.WriteLine("{0} will attack the second monster.", name);
                Console.WriteLine("");
            } else
            {
                target = 2;
                Console.WriteLine("{0} will attack the first monster.", name);
                Console.WriteLine("");
            }
        }            
    }
}