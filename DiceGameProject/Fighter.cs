using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Fighter
    {
        public int health;
        public int accuracy;
        public int damage;
        public int speed;
        public string name;
        public int goldAmount;
        public int target;
        public Fighter specificTarget;
        
       
        
        
        
        D20 d20 = new D20() { };
        

        public virtual void Attack(Fighter fighter)
        {
            if (accuracy >= d20.Roll())
            {
                int totalDamage = damage;
                fighter.health -= totalDamage;
                Console.WriteLine("{0} hit {1} for {2} damage.", name, fighter.name, totalDamage);
                Console.WriteLine("");
            }
        }
        public virtual void ResetStats()
        {
            health = 30;
            damage = 3;
            speed = 8;
            accuracy = 16;
            goldAmount = 0;

        }

        public virtual void PickTarget()
        {

        }

        public void GiveLoot(Player player)
        {
            if (health < 1)
            {
                player.goldAmount += goldAmount;
                
            }
        }
        public void DisplayStats()
        {
            Console.WriteLine("{0}: has {1} health.", name, health);
            Console.WriteLine("");
        }

        public void DisplayGold()
        {
            Console.WriteLine("{0} has {1} gold.", name, goldAmount);
            Console.WriteLine("");
        }

        
       
    }
}
