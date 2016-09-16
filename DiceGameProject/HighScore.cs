using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiceGameProject
{
    class HighScore
    {
        public string fileReader(string file)
        {
            StreamReader t = new StreamReader(file);
            string data = t.ReadToEnd();
            return data;
        }
     
        public void WriteScore(string firstName, string secondName, string score)
        {
            using (StreamWriter outputFile = new StreamWriter("highScores.txt", true))
            {
                outputFile.WriteLine(";{0} {1} & {2}", score, firstName, secondName);
            }
        }

        public string[] sortScores(string unsplitText)
        {
            string data = unsplitText;           
            string[] splitScores;
            splitScores = data.Split(';');
            Array.Sort(splitScores);
            Array.Reverse(splitScores);
            return splitScores;
        }
     
             
    } 
    
}
