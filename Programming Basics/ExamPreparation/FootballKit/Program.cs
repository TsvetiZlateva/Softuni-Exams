using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double TShirt = double.Parse(Console.ReadLine());
            double priceToWin = double.Parse(Console.ReadLine());

            double shorts = TShirt * 0.75;
            double socks = shorts * 0.20;
            double buttons = 2 * (TShirt + shorts);
            double spentMoney = (TShirt + shorts + socks + buttons) * 0.85;

            if (spentMoney >= priceToWin)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {spentMoney:f2} lv.");
            }
            else
            {
                double diff = priceToWin - spentMoney;
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {diff:f2} lv. more.");
            }

        }
    }
}
