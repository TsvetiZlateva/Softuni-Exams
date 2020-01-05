using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            double price = 0;

            switch (time)
            {
                case "day":
                    switch (month)
                    {
                        case "march": price = 10.50; break;
                        case "april": price = 10.50; break;
                        case "may": price = 10.50; break;
                        case "june": price = 12.60; break;
                        case "july": price = 12.60; break;
                        case "august": price = 12.60; break;
                    }
                    break;

                case "night":
                    switch (month)
                    {
                        case "march": 
                        case "april": 
                        case "may": price = 8.40; break;
                        case "june": 
                        case "july": 
                        case "august": price = 10.20; break;
                    }
                    break;
            }
            if (people >= 4)
            {
                price = price - price * 0.10;
            }
            if (hours >= 5)
            {
                price = price / 2.00;
            }

            double total = price * people * hours;

            Console.WriteLine($"Price per person for one hour: {price:F2}");
            Console.WriteLine($"Total cost of the visit: {total:f2}");

        }
    }
}
