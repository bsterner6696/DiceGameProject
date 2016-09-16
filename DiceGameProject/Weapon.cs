using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Weapon
    {

        
        public Weapon() { }
        D20 d20 = new D20();
        D12 d12 = new D12();
        D10 d10 = new D10();
        D8 d8 = new D8();
        D6 d6 = new D6();
        D4 d4 = new D4();

        public bool hasDagger;
        public bool hasSword;
        public bool hasBattleAxe;
        public bool hasGreatSword;
        public bool hasGiantSlayer;
        public bool hasGun;

        public int GetWeaponDamage()
        {
            if (hasGun)
            {
                return d20.Roll();
            } else if (hasGiantSlayer)
            {
                return d12.Roll();
            }else if (hasGreatSword)
            {
                return d10.Roll();
            } else if (hasBattleAxe)
            {
                return d8.Roll();
            }else if (hasSword)
            {
                return d6.Roll();
            }else if (hasDagger)
            {
                return d4.Roll();
            } else
            {
                return 0;
            }
        }

        public void EquipGun()
        {
            hasGun = true;
            Console.WriteLine("Acquired Gun");
            Console.ReadLine();
        }
        public void EquipGiantSlayer()
        {
            hasGiantSlayer = true;
            Console.WriteLine("Acquired Giant Slayer");
            Console.ReadLine();
        }
        public void EquipGreatSword()
        {
            hasGreatSword = true;
            Console.WriteLine("Acquired GreatSword");
            Console.ReadLine();
        }
        public void EquipBattleAxe()
        {
            hasBattleAxe = true;
            Console.WriteLine("Acquired BattleAxe");
            Console.ReadLine();

        }
        public void EquipSword()
        {
            hasSword = true;
            Console.WriteLine("Acquired Sword");
            Console.ReadLine();
        }
        public void EquipDagger()
        {
            hasDagger = true;
            Console.WriteLine("Acquired Dagger");
            Console.ReadLine();
        }
    }
}
