using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingHome
{
    class Program
    {
        static void Main(string[] args)
        {
            double km = double.Parse(Console.ReadLine());
            double razhod = double.Parse(Console.ReadLine());
            double priceGas = double.Parse(Console.ReadLine());
            double moneyWon = double.Parse(Console.ReadLine());

            double moneyNeeded = km / 100 * razhod * priceGas;

            if (moneyWon >= moneyNeeded)
            {
                double moneyLeft = moneyWon - moneyNeeded;
                Console.WriteLine($"You can go home. {moneyLeft:f2} money left.");
            }
            else
            {
                double part = moneyWon / 5;
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {part:f2} money.");
            }
        }
    }
}
