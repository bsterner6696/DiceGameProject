using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiceGameProject
{
    public class Game
    {
        int dayNumber;
        Player player1;
        Player player2;
        List<Monster> monsters = new List<Monster>();
        D6 d6 = new D6();
        bool alive = true;
        HighScore highScore = new HighScore();
        string score;
        public Game()
        {
            dayNumber = 1;
        }
        public Monster GetMonster(int number)
        {
            if (number == 1)
            {
                return monsters[dayNumber * 2 - 2];
            }
            else
            {
                return monsters[dayNumber * 2 - 1];
            }
        }

        public void GetNumberOfPlayers()
        {
            Console.WriteLine("Enter desired number of players. (1 or 2)");
            string numberPlayers = Console.ReadLine();
            if (numberPlayers == "1")
            {
                player1 = new HumanPlayer("player 1");
                player2 = new ComputerPlayer();
                Console.WriteLine("");
            }
            else if (numberPlayers == "2")
            {
                player1 = new HumanPlayer("player 1");
                player2 = new HumanPlayer("player 2");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Press either '1' or '2'");
                GetNumberOfPlayers();
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
                PromptToRecordScore();
            }

        }

        public void InitializeBattle()
        {
            SpawnMonsters();
            AnnounceMonsters();
            SetMonsterNames();
            Console.ReadLine();
            Console.Clear();
            GetMonster(1).DisplayStats();
            GetMonster(2).DisplayStats();            
            Battle();
        }

         public void Battle()
                {
                    AllocateTargets();      
                    AttackTargetsInOrder();
                    DisplayRoundEndStats();
                    ResolveTurn();
            UpdateScore();
            AskToContinue();

                }
        public void SpawnMonsters()
        {
            if (dayNumber < 11)
            {
                
                monsters.Add(new Gremlin());
                monsters.Add(new Gremlin());
                GetMonster(1).ResetStats();
            }
            else if (10 < dayNumber && 21 > dayNumber)
            {
                monsters.Add(new Goblin());
                monsters.Add(new Goblin());
                GetMonster(1).ResetStats();
            }
            else if (20 < dayNumber && dayNumber < 31)
            {
                monsters.Add(new DireWolf());
                monsters.Add(new DireWolf());
                GetMonster(1).ResetStats();
            }
            else if (30 < dayNumber && dayNumber < 41)
            {
                monsters.Add(new Ogre());
                monsters.Add(new Ogre());
                GetMonster(1).ResetStats();
            }
            else if (40 < dayNumber && dayNumber < 51)
            {
                monsters.Add(new RockTroll());
                monsters.Add(new RockTroll());
                GetMonster(1).ResetStats();
            }
            else if (50 < dayNumber && dayNumber < 61)
            {
                monsters.Add(new Daemon());
                monsters.Add(new Daemon());
                GetMonster(1).ResetStats();

            }
            else if (60 < dayNumber && dayNumber < 71)
            {
                monsters.Add(new AvatarOfTheDamned());
                monsters.Add(new AvatarOfTheDamned());
                GetMonster(1).ResetStats();
            }
            else if (70 < dayNumber)
            {
                monsters.Add(new Dragon());
                monsters.Add(new Dragon());
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
            if (fighters[3].health > 0)
            {
                fighters[3].Attack(fighters[3].specificTarget);
            }
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


        public void PromptToRecordScore()
        {
            Console.WriteLine("Do you wish to record your score in the score log?  Enter 'yes' or 'no'");
            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                ExecuteScoring();
            }
            else
            {
                Console.WriteLine("Thanks for playing.");
            }
        }
        public void GetScore()
        {
            int totalGold = player1.maxGold + player2.maxGold;
            score = totalGold.ToString();
        }
        public void ExecuteScoring()
        {
            GetScore();
            highScore.WriteScore(player1.name, player2.name, score);
            ListHighScores();
        }

        public void ListHighScores()
        {
            Console.WriteLine("HIGH SCORES");
            Console.WriteLine("");
            string[] scores = highScore.SortScores(highScore.ReadFile("highScores.txt"));
            foreach (string s in scores)
            {
                Console.WriteLine(s);
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        public void ResolveTurn()
        {

            if (player1.health < 1 || player2.health < 1)
            {
                Console.WriteLine("One or more player has died.  Game Over.");
                Console.WriteLine("");
                alive = false;
                Console.ReadLine();
                Console.Clear();
            } else if (GetMonster(1).health < 1 && GetMonster(2).health < 1)
            {
                GetMonster(1).GiveLoot(player1);
                GetMonster(1).GiveLoot(player2);
                GetMonster(2).GiveLoot(player1);
                GetMonster(2).GiveLoot(player2);
                Console.WriteLine("Monsters slain. Got {0} gold.", (GetMonster(1).goldAmount + GetMonster(2).goldAmount));
                Console.WriteLine("");
                Console.WriteLine("{0} has {1} gold.", player1.name, player1.goldAmount);
                Console.WriteLine("{0} has {1} gold.", player2.name, player2.goldAmount);

                Console.ReadLine();
                Console.Clear();
            } else
            {
                Battle();
            }
        }
        public void UpdateScore()
        {
            player1.UpdateScore();
            player2.UpdateScore();

        }

        public void DisplayRoundEndStats()
        {

            Console.ReadLine();
            Console.Clear();
            if (GetMonster(1).health < 1)
            {
                Console.WriteLine("{0} 1 defeated.", GetMonster(1).name);
                Console.WriteLine("");
            }
            else
            {
                GetMonster(1).DisplayStats();
            }

            if (GetMonster(2).health < 1)
            {
                Console.WriteLine("{0} 2 defeated.", GetMonster(2).name);
                Console.WriteLine("");
            }
            else
            {
                GetMonster(2).DisplayStats();
            }
            Console.ReadLine();
            Console.Clear();
        }

        public void AskToContinue()
        {
            if (alive)
            {
                Console.WriteLine("Continue? Type yes to continue or no to quit.");
                string continueChoice = Console.ReadLine();
                if (continueChoice == "yes")
                {

                    alive = true;
                }
                else if (continueChoice == "no")
                {
                    alive = false;
                }
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
            Console.ReadLine();
            Console.Clear();
        }
       
        
    }
}
