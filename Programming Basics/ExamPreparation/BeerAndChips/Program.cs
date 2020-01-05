using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double buget = double.Parse(Console.ReadLine());
            int beer = int.Parse(Console.ReadLine());
            int chips = int.Parse(Console.ReadLine());

            double beerPrice = beer * 1.20;
            double chipsPrice = Math.Ceiling(chips * (beerPrice * 0.45));
            double moneySpent = beerPrice + chipsPrice;
            double moneyResult = Math.Abs(buget - moneySpent);

            if (buget >= moneySpent)
            {
                Console.WriteLine($"{name} bought a snack and has {moneyResult:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {moneyResult:F2} more leva!");
            }
        }
    }
}
