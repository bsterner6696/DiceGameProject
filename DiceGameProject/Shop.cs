using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    public class Shop
    {
        public Weapon weapon = new Weapon();
        public string request;
        public void DisplayShopOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("For Sale");
            Console.WriteLine("");
            Console.WriteLine("Dagger: 20g");
            Console.WriteLine("Sword: 50g");
            Console.WriteLine("BattleAxe: 100g");
            Console.WriteLine("GreatSword: 200g");
            Console.WriteLine("GiantSlayer: 400g");
            Console.WriteLine("Secret Weapon: 2000g");
            Console.WriteLine(" ");
            Console.WriteLine("Night at inn: 10 g");
            Console.WriteLine(" ");
            Console.WriteLine("Training at dojo, 100g");
            Console.WriteLine(" ");
            Console.WriteLine("Type what you want, or 'none' if you're broke.");
        }

    }
}
