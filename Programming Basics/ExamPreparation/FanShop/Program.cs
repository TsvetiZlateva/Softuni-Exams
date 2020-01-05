using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int buget = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int price = 0;
            int moneySpent = 0;

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();

                switch (item)
                {
                    case "hoodie": price = 30; break;
                    case "keychain": price = 4; break;
                    case "T-shirt": price = 20; break;
                    case "flag": price = 15; break;
                    case "sticker": price = 1; break;
                }

                moneySpent += price;
            }

            int diff = Math.Abs(buget - moneySpent);

            if (buget >= moneySpent)
            {
                Console.WriteLine($"You bought {n} items and left with {diff} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {diff} more lv.");
            }
        }
    }
}
