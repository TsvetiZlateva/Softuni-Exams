using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeymoon
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            double nights = double.Parse(Console.ReadLine());
            double price = 0;
            double finalPrice = 0;

            switch (town)
            {
                case "Cairo": price = 250 * nights * 2 + 600; break;
                case "Paris": price = 150 * nights * 2 + 350; break;
                case "Lima": price = 400 * nights * 2 + 850; break;
                case "New York": price = 300 * nights * 2 + 650; break;
                case "Tokyo": price = 350 * nights * 2 + 700; break;
            }

            if (nights >= 1 && nights <= 4 && (town == "Cairo" || town == "New York"))
            {
                finalPrice = price * 0.97;
            }
            else if (nights <= 9 && nights >= 5 && (town == "Cairo" || town == "New York"))
            {
                finalPrice = price * 0.95;
            }
            else if (nights <= 9 && nights >= 5 && town == "Paris")
            {
                finalPrice = price * 0.93;
            }
            else if (nights >= 10 && nights <= 24 && town == "Cairo")
            {
                    finalPrice = price * 0.90;
                }
                else if (nights >= 10 && nights <= 24 && (town == "Paris" || town == "New York" || town == "Tokyo"))
                {
                    finalPrice = price * 0.88;
                }
 
            else if (nights >= 25 && nights <= 49 && (town == "Cairo" || town == "Tokyo"))
            {
               
                    finalPrice = price * 0.83;
                }
                else if (nights >= 25 && nights <= 49 && (town == "New York" || town == "Lima"))
                {
                    finalPrice = price * 0.81;
                }
                else if (nights >= 25 && nights <= 49 && town == "Paris")
                {
                    finalPrice = price * 0.78;
                }
   
            else if (nights >= 50)
            {
                finalPrice = price * 0.70;
            }

            double diff = Math.Abs(buget - finalPrice);

            if (buget >= finalPrice)
            {
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {diff:f2} leva.");
            }
        }
    }
}
