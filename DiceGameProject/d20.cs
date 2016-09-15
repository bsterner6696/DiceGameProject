using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class D20
    {
        Random random = new Random();
        public D20() { }
        public int Roll()
        {
            return random.Next(1, 21);
        }
    }
}
