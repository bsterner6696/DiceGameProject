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
        public int maxHealth;
        public string description;
        public Shop shop = new Shop();
        
        D20 d20 = new D20() { };
        

        public void Attack(Fighter fighter)
        {
            if (accuracy >= d20.Roll())
            {
                int totalDamage = damage + shop.weapon.GetWeaponDamage();
                fighter.health -= totalDamage;
                Console.WriteLine("{0} hit {1} for {2} damage.", name, fighter.name, totalDamage);
                Console.WriteLine("");
            }
        }
        public void PickHumanTargetAtRandom()
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

        public void Shop()
        {
            string shopRequest = Console.ReadLine();
            switch (shopRequest.ToLower())
            {
                case "dagger":
                    if (goldAmount >= 20)
                    {
                        shop.weapon.EquipDagger();
                        goldAmount -= 20;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }


                    break;
                case "sword":
                    if (goldAmount >= 50)
                    {
                        shop.weapon.EquipSword();
                        goldAmount -= 50;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "battleaxe":
                case "battle axe":
                    if (goldAmount >= 100)
                    {
                        shop.weapon.EquipBattleAxe();
                        goldAmount -= 100;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "greatsword":
                case "great sword":
                    if (goldAmount >= 200)
                    {
                        shop.weapon.EquipGreatSword();
                        goldAmount -= 200;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "giantslayer":
                case "giant slayer":
                    if (goldAmount >= 400)
                    {
                        shop.weapon.EquipGiantSlayer();
                        goldAmount -= 400;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }
                    break;
                case "secret weapon":
                case "secretweapon":
                case "secret":
                    if (goldAmount >= 2000)
                    {
                        shop.weapon.EquipGun();
                        goldAmount -= 2000;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "rest at inn":
                case "rest":
                case "inn":
                case "restatinn":
                    if (goldAmount >= 10)
                    {
                        health = maxHealth;
                        Console.WriteLine("{0} rested and is back to full health of {1}", name, maxHealth);
                        Shop();
                    } else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }
                    break;
                case "train":
                case "dojo":
                case "trainatdojo":
                case "train at dojo":
                case "get swole":
                    if (goldAmount >= 100)
                    {
                        Train();
                        goldAmount -= 100;
                    }
                    else
                    {
                        
                        Console.WriteLine("Get something you can afford.");
                        

                        Shop();
                    }

                    break;
                case "none":
                case "leave":
                    break;
                default:
                    Console.WriteLine("Pick a valid option, ya dingus.");
                    Shop();
                    break;
            }
            Console.Clear();
        }
        public void Train()
        {
            Console.WriteLine("");
            Console.WriteLine("Options to train:");
            Console.WriteLine("");
            Console.WriteLine("Max Health");
            Console.WriteLine("Base Damage");
            Console.WriteLine("Speed");
            Console.WriteLine("Accuracy");
            Console.WriteLine("");
            Console.WriteLine("Enter what you want to train.");
            Console.WriteLine("");
            string tChoice = Console.ReadLine();
                switch (tChoice.ToLower())
            {
                case "health":
                case "max health":
                case "maxhealth":
                    maxHealth += 5;
                    health = maxHealth;
                    Console.WriteLine("");
                    Console.WriteLine("Max health increased by 5 to {0}", maxHealth);
                    break;
                case "base damage":
                case "damage":
                case "basedamage":
                    damage += 2;
                    Console.WriteLine("");
                    Console.WriteLine("Base damage increased by 2 to {0}", damage);
                    break;
                case "speed":
                    speed += 2;
                    Console.WriteLine("");
                    Console.WriteLine("Speed increased by 2 to {0}", speed);
                    break;
                case "accuracy":
                    accuracy += 1;
                    Console.WriteLine("");
                    Console.WriteLine("Accuracy increased by 1 to {0}", accuracy);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Pick a valid option");
                    Train();
                    break;
            }

        }
    }
}
