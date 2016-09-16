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
            string tChoice = Console.ReadLine();
            switch (tChoice)
            {
                case "1":
                    target = 2;
                    break;
                case "2":
                    target = 1;
                    break;
                default:
                    Console.WriteLine("Choose again");
                    PickTarget();
                    break;
            }
        }
        public HumanPlayer(string name)
        {
            this.name = name;
        }
    }
}
