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
        Player player2 = new Player();
        List<Fighter> fighters = new List<Fighter>();
        D4 d4 = new D4();
        D6 d6 = new D6();
        D8 d8 = new D8();
        D10 d10 = new D10();
        D12 d12 = new D12();
        D20 d20 = new D20();
        bool alive = true;
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
                    player1 = new HumanPlayer("player 1");
                    player2 = new ComputerPlayer();
                    break;
                case "2":
                    player1 = new HumanPlayer("player 1");
                    player2 = new HumanPlayer("player 2");
                    break;
                default:
                    Console.WriteLine("Enter valid choice. (1 or 2)");
                    GetNumberOfPlayers();
                    break;
            }
        }
        public void AssignNames()
        {
            player1.SetName();
            player2.SetName();
            
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
            } else
            {

            }

        }

        

        public void AllocateTargets()
        {
            player1.PickTarget();
            if (player1.target == 1)
            {
                player1.specificTarget = GetMonster(2);
            } else
            {
                player1.specificTarget = GetMonster(1);
            }
             player2.PickTarget();
             if (player2.target == 1)
                {
                    player2.specificTarget = GetMonster(2);
                }
                else
                {
                    player2.specificTarget = GetMonster(1);
                }
            
            GetMonster(2).PickTarget();
            if (GetMonster(2).target == 4)
            {
                 GetMonster(2).specificTarget = player1;
            }
            else
            {
                GetMonster(2).specificTarget = player2;
            }
            GetMonster(1).PickTarget();
            if (GetMonster(1).target == 4)
            {
                GetMonster(1).specificTarget = player1;
            }
            else
            {
                GetMonster(1).specificTarget = player2;
            }

        }
        public Fighter[] DetermineAttackOrder()
        {
            int player1Speed = player1.speed + d6.Roll();
            int player2Speed = player2.speed + d6.Roll();
            int monster1Speed = GetMonster(1).speed + d6.Roll();
            int monster2Speed = GetMonster(2).speed + d6.Roll();
            int[] speeds = { player1Speed, player2Speed, monster1Speed, monster2Speed };
            Fighter[] fightersSpeed = { player1, player2, GetMonster(1), GetMonster(2) };
            Array.Sort(speeds, fightersSpeed);
            return fightersSpeed;
        }
        public void AttackTargetsInOrder()
        {
            Fighter[] fighters = DetermineAttackOrder();
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
        
        public void AddPlayersToBattle()
        {
            fighters.Add(player1);
            fighters.Add(player2);
        }
        public void SpawnMonsters()
        {
            if (dayNumber < 11)
            {
                fighters.Add(new Gremlin());
                fighters.Add(new Gremlin());
                GetMonster(1).ResetStats();
            }
            else if (10 < dayNumber && 21 > dayNumber)
            {
                fighters.Add(new Goblin());
                fighters.Add(new Goblin());
                GetMonster(1).ResetStats();
            }
            else if (20 < dayNumber && dayNumber < 31)
            {
                fighters.Add(new DireWolf());
                fighters.Add(new DireWolf());
                GetMonster(1).ResetStats();
            }
            else if (30 < dayNumber && dayNumber < 41)
            {
                fighters.Add(new Ogre());
                fighters.Add(new Ogre());
                GetMonster(1).ResetStats();
            }
            else if (40 < dayNumber && dayNumber < 51)
            {
                fighters.Add(new RockTroll());
                fighters.Add(new RockTroll());
                GetMonster(1).ResetStats();
            }
            else if (50 < dayNumber && dayNumber < 61)
            {
                fighters.Add(new Daemon());
                fighters.Add(new Daemon());
                GetMonster(1).ResetStats();
            }
            else if (60 < dayNumber && dayNumber < 71)
            {
                fighters.Add(new AvatarOfTheDamned());
                fighters.Add(new AvatarOfTheDamned());
                GetMonster(1).ResetStats();
            }
            else if (70 < dayNumber)
            {
                fighters.Add(new Dragon());
                fighters.Add(new Dragon());
                GetMonster(1).ResetStats();
            }
            
        }
        public void AnnounceMonsters()
        {
            Console.WriteLine("Two {0}s appeared.", GetMonster(1).name);
            Console.WriteLine("");
            Console.WriteLine(GetMonster(1).description);
            Console.WriteLine("");

        }
        public void SetMonsterNames()
        {
            GetMonster(1).firstOrSecond = 1;
            GetMonster(1).SetName();
            GetMonster(2).SetName();
        }
        public void InitializeBattle()
        {
            AddPlayersToBattle();
            SpawnMonsters();
            AnnounceMonsters();
            SetMonsterNames();
            Console.ReadKey();
            Console.Clear();
            GetMonster(1).DisplayStats();
            GetMonster(2).DisplayStats();            
            Battle();
        }
        public void Battle()
        {
            AllocateTargets();      
            AttackTargetsInOrder();
            ResolveTurn();
            
        }
        public Fighter GetPlayers(int number)
        {
            if (number == 1)
            {
                return fighters[dayNumber * 4 - 4];
            } else
            {
                return fighters[dayNumber * 4 - 3];
            }
        }
        public void DisplayMonstersHealth()
        {
            GetMonster(1).DisplayStats();
            GetMonster(2).DisplayStats();
        }
        public Fighter GetMonster(int number)
        {
            if (number== 1)
            {
                return fighters[dayNumber * 4 - 2];
            } else {
                return fighters[dayNumber * 4 - 1];
            }
        }
        public void ResolveTurn()
        {

            Console.ReadKey();
            if (GetMonster(1).health < 1)
            {
                Console.WriteLine("{0} 1 defeated.", GetMonster(1).name);
                Console.WriteLine("");
            } else
            {
                GetMonster(1).DisplayStats();
            }
            
            if (GetMonster(2).health < 1)
            {
                Console.WriteLine("{0} 2 defeated.", GetMonster(2).name);
                Console.WriteLine("");
            } else
            {
                GetMonster(2).DisplayStats();
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
                GetMonster(1).GiveLoot(player1);
                GetMonster(1).GiveLoot(player2);
                GetMonster(2).GiveLoot(player1);
                GetMonster(2).GiveLoot(player2);
                Console.WriteLine("Monsters slain. Got {1} gold.", (GetMonster(1).goldAmount + GetMonster(2).goldAmount));
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
