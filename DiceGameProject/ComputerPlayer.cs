using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer() { }
        D4 d4 = new D4();
        public void PickTargetAtRandom()
        {
            if (d4.Roll() > 2)
            {
                target = 1;
                Console.WriteLine("{0} will attack the second monster.", name);
            } else
            {
                target = 2;
                Console.WriteLine("{0} will attack the first monster.", name);
            }
        }
            
                
    }
}
