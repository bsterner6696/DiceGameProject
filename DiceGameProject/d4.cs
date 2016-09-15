using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class D4
    {
        Random random = new Random();
        public D4() { }
        public int Roll()
        {
                return random.Next(1, 5);
        }
    }
}
