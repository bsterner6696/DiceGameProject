using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class HumanPlayer : Player
    {
        public override void PickTarget()
        {
            Console.WriteLine("{0}, Do you want to attack the first or second monster?  Enter '1' or '2'", name);
            ConsoleKeyInfo tChoice = Console.ReadKey();
            if (tChoice.KeyChar == '1')
            {
                target = 2;
                Console.WriteLine("");
            } else if (tChoice.KeyChar == '2')
            {
                target = 1;
                Console.WriteLine("");
            } else
            {
                Console.WriteLine("Press '1' or '2'");
                PickTarget();
            }
        }
        public HumanPlayer(string name)
        {
            this.name = name;
        }
    }
}
