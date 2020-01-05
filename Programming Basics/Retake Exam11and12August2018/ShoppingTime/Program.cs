using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double breakTime = double.Parse(Console.ReadLine());
            double pricePart = double.Parse(Console.ReadLine());
            double priceProgram = double.Parse(Console.ReadLine());
            double priceFrappe = double.Parse(Console.ReadLine());

            double timeLeft = breakTime - 5 - 3 * 2 - 2 * 2;
            double moneySpent = priceFrappe + 2 * priceProgram + 3 * pricePart;

            Console.WriteLine($"{moneySpent:F2}");
            Console.WriteLine(timeLeft);
        }
    }
}
