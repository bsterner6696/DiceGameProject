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
        public Shop shop = new Shop();
        public int maxHealth;



        public Player() {
            
            damage = 3;
            health = 30;
            maxHealth = 30;
            speed = 8;
            accuracy = 16;
            goldAmount = 0;
            
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
        public virtual void SetName()
        {
            Console.WriteLine("Enter name for {0}.", name);
            name = Console.ReadLine();
        }
        public int maxGold;
        public void UpdateScore()
        {
            if (goldAmount > maxGold)
            {
                maxGold = goldAmount;
            }
        }
        public void Shop()
        {
            string shopRequest = Console.ReadLine();
            switch (shopRequest.ToLower())
            {
                case "dagger":
                    if (goldAmount >= 40)
                    {
                        shop.weapon.EquipDagger();
                        goldAmount -= 40;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }


                    break;
                case "sword":
                    if (goldAmount >= 100)
                    {
                        shop.weapon.EquipSword();
                        goldAmount -= 100;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "battleaxe":
                case "battle axe":
                    if (goldAmount >= 200)
                    {
                        shop.weapon.EquipBattleAxe();
                        goldAmount -= 200;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "greatsword":
                case "great sword":
                    if (goldAmount >= 400)
                    {
                        shop.weapon.EquipGreatSword();
                        goldAmount -= 400;
                    }
                    else
                    {
                        Console.WriteLine("Get something you can afford.");
                        Shop();
                    }

                    break;
                case "giantslayer":
                case "giant slayer":
                    if (goldAmount >= 1000)
                    {
                        shop.weapon.EquipGiantSlayer();
                        goldAmount -= 1000;
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
                    if (goldAmount >= 5000)
                    {
                        shop.weapon.EquipGun();
                        goldAmount -= 5000;
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
                        goldAmount -= 10;
                        Console.WriteLine("{0} rested and is back to full health of {1}", name, maxHealth);
                        DisplayGold();
                        shop.DisplayShopOptions();
                        Shop();
                    }
                    else
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
