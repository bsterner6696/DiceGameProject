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
        public override void Attack(Fighter fighter)
        {
            if (accuracy >= d20.Roll())
            {
                int totalDamage = damage + shop.weapon.GetWeaponDamage();
                fighter.health -= totalDamage;
                Console.WriteLine("{0} hit {1} for {2} damage.", name, fighter.name, totalDamage);
                Console.WriteLine("");
            }
        }
        
    }
}
