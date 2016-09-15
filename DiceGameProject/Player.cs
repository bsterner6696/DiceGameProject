using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Player : Fighter
    {
        
        D20 d20 = new D20() { };
   
        

        public Player() {
            
            damage = 3;
            health = 30;
            maxHealth = 30;
            speed = 8;
            accuracy = 16;
            goldAmount = 0;
            description = "You.";
        }
       
        public void GetPlayerName()
        {
            Console.WriteLine("{0} enter name:", name);
            name = Console.ReadLine();
        }   
        public void PickTarget()
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
        
    }
}
