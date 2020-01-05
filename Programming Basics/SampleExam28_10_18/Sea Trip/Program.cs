using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double souvenirs = double.Parse(Console.ReadLine());
            double hotel = double.Parse(Console.ReadLine());

            double moneyForFood = 3 * food;
            double moneyForSouvenirs = 3 * souvenirs;
            double moneyForHotel = hotel * 0.90 + hotel * 0.85 + hotel * 0.80;
            double moneyForGas = 420 / 100.00 * 7 * 1.85;

            double allMoneyNeeded = moneyForFood + moneyForSouvenirs + moneyForHotel + moneyForGas;

            Console.WriteLine($"Money needed: {allMoneyNeeded:F2}");
        }
    }
}
