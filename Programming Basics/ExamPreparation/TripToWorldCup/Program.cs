using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double ticketGo = double.Parse(Console.ReadLine());
            double ticketBack = double.Parse(Console.ReadLine());
            double ticketGame = double.Parse(Console.ReadLine());
            int numGames = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double moneyForAirplane = ticketGo + ticketBack;
            double moneySpent = (moneyForAirplane - moneyForAirplane * discount / 100) + ticketGame * numGames;
            double allMoney = 6 * moneySpent;

            Console.WriteLine($"Total sum: {allMoney:f2} lv.");
            Console.WriteLine($"Each friend has to pay {moneySpent:f2} lv.");

        }
    }
}
