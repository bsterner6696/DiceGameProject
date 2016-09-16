using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DiceGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HighScore highScore = new HighScore();

            Game game = new Game();
            game.PlayGame();
        }
    }
}
