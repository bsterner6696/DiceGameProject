using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Daemon : Monster
    {
        D4 d4 = new D4();
        D10 d10 = new D10();
        D6 d6 = new D6();
        D12 d12 = new D12();
        D8 d8 = new D8();
        D20 d20 = new D20();

        public Daemon()
        {
            name = "Lesser Chaos Daemon";
            description = "Blood for the Blood God.";
            GetDaemonStats();
        }
        public void GetDaemonStats()
        {
            health = d20.Roll();
            damage = d8.Roll() * 3;
            accuracy = d20.Roll();
            speed = d20.Roll();
            goldAmount = d20.Roll() * 5;
        }
    }
}
