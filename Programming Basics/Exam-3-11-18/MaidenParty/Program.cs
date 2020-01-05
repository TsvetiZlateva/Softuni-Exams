using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaidenParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int loveLetters = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int keychains = int.Parse(Console.ReadLine());
            int cartoons = int.Parse(Console.ReadLine());
            int surprises = int.Parse(Console.ReadLine());
            double profit = 0;

            double price = loveLetters * 0.60 + roses * 7.20 + keychains * 3.60 + cartoons * 18.20 + surprises * 22.00;
            double products = loveLetters + roses + keychains + cartoons + surprises;

            if (products >= 25)
            {
                profit = (price - price * 0.35) * 0.90;
            }
            else
            {
                profit = price - price * 0.10;
            }

            double diff = Math.Abs(buget - profit);

            if (profit >= buget)
            {
                Console.WriteLine($"Yes! {diff:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {diff:f2} lv needed.");
            }
                 
        }
    }
}
