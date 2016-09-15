using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Game
    {
        int dayNumber;
        Player player1 = new Player();
        ComputerPlayer player2 = new ComputerPlayer();
        List<Fighter> fighters = new List<Fighter>();
        D4 d4 = new D4();
        D6 d6 = new D6();
        D8 d8 = new D8();
        D10 d10 = new D10();
        D12 d12 = new D12();
        D20 d20 = new D20();
        bool alive = true;

        public int numberOfPlayers;
        public Game()
        {
            dayNumber = 1;
        }
              
        
        public void GetNumberOfPlayers()
        {
            Console.WriteLine("Enter desired number of players. (1 or 2)");
            string numberPlayers = Console.ReadLine();
            switch (numberPlayers)
            {
                case "1":
                    numberOfPlayers = 1;
                    break;
                case "2":
                    numberOfPlayers = 2;
                    break;
                default:
                    Console.WriteLine("Enter valid choice. (1 or 2)");
                    GetNumberOfPlayers();
                    break;
            }
        }
        public void AssignNames()
        {
            player1.name = "Player1";
            player1.GetPlayerName();
            if (numberOfPlayers == 1)
            {
                player2.name = "Frank";
            } else
            {
                player2.name = "Player2";
                player2.GetPlayerName();
            }
            
        }
        public void PlayGame()
        {
            GetNumberOfPlayers();
            AssignNames();
            Console.Clear();
            GoThroughDay();
  
        }
        public void GoThroughDay()
        {
            InitializeBattle();
            if (alive)
            {
                Celebrate();
                Console.WriteLine("{0}, welcome to the village.  After you and your partner make your choices here the next day will begin.", player1.name);
                Console.WriteLine("");
                player1.DisplayStats();
                player1.DisplayGold();
                player1.shop.DisplayShopOptions();
                player1.Shop();
                Console.WriteLine("{0}, welcome to the village. After you make your choice the next day will begin.", player2.name);
                Console.WriteLine();
                player2.DisplayStats();
                player2.DisplayGold();
                player1.shop.DisplayShopOptions();
                player2.Shop();
                AdvanceDay();
                GoThroughDay();
            }

        }

        

        public void AllocateTargets()
        {
            player1.PickTarget();
            if (player1.target == 1)
            {
                player1.specificTarget = fighters[dayNumber * 4 - 1];
            } else
            {
                player1.specificTarget = fighters[dayNumber * 4 - 2];
            }
            
            if (numberOfPlayers == 1)
            {
                player2.PickTargetAtRandom();
                if (player2.target == 1)
                {
                    player2.specificTarget = fighters[dayNumber * 4 - 1];
                }
                else
                {
                    player2.specificTarget = fighters[dayNumber * 4 - 2];
                }
            } else
            {
                player2.PickTarget();
                if (player2.target == 1)
                {
                    player2.specificTarget = fighters[dayNumber * 4 - 1];
                }
                else
                {
                    player2.specificTarget = fighters[dayNumber * 4 - 2];
                }
            }
            fighters[dayNumber * 4 - 1].PickHumanTargetAtRandom();
            if (fighters[dayNumber * 4 - 1].target == 4)
            {
                 fighters[dayNumber * 4 -1].specificTarget = player1;
            }
            else
            {
                fighters[dayNumber * 4 - 1].specificTarget = player2;
            }
            fighters[dayNumber * 4 - 2].PickHumanTargetAtRandom();
            if (fighters[dayNumber * 4 - 2].target == 4)
            {
                fighters[dayNumber * 4 - 2].specificTarget = player1;
            }
            else
            {
                fighters[dayNumber * 4 - 2].specificTarget = player2;
            }

        }
        public void AttackTargetsInOrder()
        {
            int player1Speed = player1.speed + d6.Roll();
            int player2Speed = player2.speed + d6.Roll();
            int monster1Speed = fighters[dayNumber * 4 - 1].speed + d6.Roll();
            int monster2Speed = fighters[dayNumber * 4 - 2].speed + d6.Roll();
            int[] speeds = { player1Speed, player2Speed, monster1Speed, monster2Speed };
            Fighter[] fightersSpeed = { player1, player2, fighters[dayNumber * 4 - 1], fighters[dayNumber * 4 - 2] };
            Array.Sort(speeds, fightersSpeed);
            fighters[3].Attack(fighters[3].specificTarget);
            if (fighters[2].health > 0)
            {
                fighters[2].Attack(fighters[2].specificTarget);
            }
            if (fighters[1].health > 0)
            {
                fighters[1].Attack(fighters[1].specificTarget);
            }
            if (fighters[0].health > 0)
            {
                fighters[0].Attack(fighters[0].specificTarget);
            }

        }
        
        
        public void SpawnMonsters()
        {
            fighters.Add(player1);
            fighters.Add(player2);
            if (dayNumber < 11)
            {
                fighters.Add(new Gremlin());
                fighters.Add(new Gremlin());
                fighters[dayNumber * 4 - 2].health = d4.Roll() + 1;
                fighters[dayNumber * 4 - 2].damage = d4.Roll();
                fighters[dayNumber * 4 - 2].accuracy = 6 + d10.Roll();
                fighters[dayNumber * 4 - 2].speed = 4 + d6.Roll();
                fighters[dayNumber * 4 - 2].goldAmount = d12.Roll();
            }
            else if (10 < dayNumber && 21 > dayNumber)
            {
                fighters.Add(new Goblin());
                fighters.Add(new Goblin());
                fighters[dayNumber * 4 - 2].health = d6.Roll() + 1;
                fighters[dayNumber * 4 - 2].damage = d6.Roll();
                fighters[dayNumber * 4 - 2].accuracy = 8 + d8.Roll();
                fighters[dayNumber * 4 - 2].speed = 8 + d4.Roll();
                fighters[dayNumber * 4 - 2].goldAmount = 3 * d8.Roll();
            } else if ( 20 < dayNumber && dayNumber < 31)
            {
                fighters.Add(new DireWolf());
                fighters.Add(new DireWolf());
                fighters[dayNumber * 4 - 2].health = d8.Roll() + 5;
                fighters[dayNumber * 4 - 2].damage = d6.Roll() + 4;
                fighters[dayNumber * 4 - 2].accuracy = 12 + d4.Roll();
                fighters[dayNumber * 4 - 2].speed = 9;
                fighters[dayNumber * 4 - 2].goldAmount = d20.Roll() + d12.Roll() + d8.Roll();
            } else if (30 < dayNumber && dayNumber < 41)
            {
                fighters.Add(new Ogre());
                fighters.Add(new Ogre());
                fighters[dayNumber * 4 - 2].health = d8.Roll() + 10;
                fighters[dayNumber * 4 - 2].damage = d12.Roll() + 4;
                fighters[dayNumber * 4 - 2].accuracy = 13;
                fighters[dayNumber * 4 - 2].speed = 5;
                fighters[dayNumber * 4 - 2].goldAmount = d20.Roll() * 3;
            } else if (40 < dayNumber && dayNumber < 51)
            {
                fighters.Add(new RockTroll());
                fighters.Add(new RockTroll());
                fighters[dayNumber * 4 - 2].health = 20;
                fighters[dayNumber * 4 - 2].damage = d12.Roll() * 2;
                fighters[dayNumber * 4 - 2].accuracy = 12 + d4.Roll();
                fighters[dayNumber * 4 - 2].speed = 6;
                fighters[dayNumber * 4 - 2].goldAmount = 30 + d20.Roll();
            } else if ( 50 < dayNumber && dayNumber < 61)
            {
                fighters.Add(new Daemon());
                fighters.Add(new Daemon());
                fighters[dayNumber * 4 - 2].health = d20.Roll();
                fighters[dayNumber * 4 - 2].damage = d8.Roll() * 3;
                fighters[dayNumber * 4 - 2].accuracy = d20.Roll();
                fighters[dayNumber * 4 - 2].speed = d20.Roll();
                fighters[dayNumber * 4 - 2].goldAmount = d20.Roll() * 5;
            } else if (60 < dayNumber && dayNumber < 71)
            {
                fighters.Add(new AvatarOfTheDamned());
                fighters.Add(new AvatarOfTheDamned());
                fighters[dayNumber * 4 - 2].health = d4.Roll() * 5;
                fighters[dayNumber * 4 - 2].damage = d4.Roll() + d6.Roll() + d8.Roll() + d10.Roll() + d12.Roll();
                fighters[dayNumber * 4 - 2].accuracy = d4.Roll() * 5;
                fighters[dayNumber * 4 - 2].speed = d8.Roll() * 3;
                fighters[dayNumber * 4 - 2].goldAmount = d20.Roll() * 5 + d10.Roll() * 10;
            } else if (70 < dayNumber)
            {
                fighters.Add(new Dragon());
                fighters.Add(new Dragon());
                fighters[dayNumber * 4 - 2].health = d8.Roll() * 5;
                fighters[dayNumber * 4 - 2].damage = d20.Roll() + d4.Roll() + d6.Roll() + d8.Roll() + d10.Roll() + d12.Roll();
                fighters[dayNumber * 4 - 2].accuracy = 16 + d4.Roll();
                fighters[dayNumber * 4 - 2].speed = 30;
                fighters[dayNumber * 4 - 2].goldAmount = d20.Roll() * 20;
            }

            Console.WriteLine("Two {0}s appeared.", fighters[dayNumber * 4 - 1].name);
            Console.WriteLine("");
            Console.WriteLine(fighters[dayNumber * 4 - 1].description);
            Console.WriteLine("");
            
        }
        public void InitializeBattle()
        {
            SpawnMonsters();
            Console.ReadKey();
            Console.Clear();
            fighters[dayNumber * 4 - 1].DisplayStats();
            fighters[dayNumber * 4 - 2].DisplayStats();
            
            Battle();
        }
        public void Battle()
        {
            AllocateTargets();      
            AttackTargetsInOrder();
            ResolveTurn();
            
        }

        public void ResolveTurn()
        {
           
            fighters[dayNumber * 4 - 3].DisplayStats();
            fighters[dayNumber * 4 - 4].DisplayStats();
            Console.WriteLine("1st Monster Status:");
            Console.WriteLine("");
            if (fighters[dayNumber * 4 - 2].health < 1)
            {
                Console.WriteLine("{0} 1 defeated.", fighters[dayNumber * 4 - 2].name);
                Console.WriteLine("");
            } else
            {
                fighters[dayNumber * 4 - 2].DisplayStats();
            }
            Console.WriteLine("2nd monster Status:");
            Console.WriteLine("");
            if (fighters[dayNumber * 4 - 1].health < 1)
            {
                Console.WriteLine("{0} 2 defeated.", fighters[dayNumber * 4 - 1].name);
                Console.WriteLine("");
            } else
            {
                fighters[dayNumber * 4 - 1].DisplayStats();
            }
            Console.ReadKey();
            Console.Clear();
            if (player1.health < 1 || player2.health < 1)
            {
                Console.WriteLine("One or more player has died.  Game Over.");
                Console.WriteLine("");
                alive = false;
                Console.ReadKey();
            } else if (fighters[dayNumber * 4 -1].health < 1 && fighters[dayNumber * 4 - 2].health < 1)
            {
                fighters[dayNumber * 4 - 1].GiveLoot(player1);
                fighters[dayNumber * 4 - 1].GiveLoot(player2);
                fighters[dayNumber * 4 - 2].GiveLoot(player1);
                fighters[dayNumber * 4 - 2].GiveLoot(player2);
                Console.WriteLine("{0}s slain. Got {1} gold.", fighters[dayNumber * 4 -1].name, (fighters[dayNumber * 4 - 1].goldAmount + fighters[dayNumber * 4 - 2].goldAmount));
                Console.WriteLine("");
                Console.WriteLine("{0} has {1} gold.", player1.name, player1.goldAmount);
                Console.WriteLine("{0} has {1} gold.", player2.name, player2.goldAmount);

                Console.ReadKey();
            } else
            {
                Battle();
            }
        }
        public void AdvanceDay()
        {
            dayNumber += 1;
        }
        public void Celebrate()
        {
            Console.Clear();
            Console.WriteLine("Congratulations you cleared day number {0}.  Now you get to go to the village to shop, train, or rest, if you have the coin.", dayNumber);
            Console.ReadKey();
        }

    }
}
