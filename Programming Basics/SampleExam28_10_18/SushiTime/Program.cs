using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int orders = int.Parse(Console.ReadLine());
            char typeOfOrder = char.Parse(Console.ReadLine());
            double sushiPrice = 0;

            switch (restaurant)
            {
                case "Sushi Zone":
                    switch (sushi)
                    {
                        case "sashimi": sushiPrice = 4.99; break;
                        case "maki": sushiPrice = 5.29; break;
                        case "uramaki": sushiPrice = 5.99; break;
                        case "temaki": sushiPrice = 4.29; break;
                    }
                    break;

                case "Sushi Time":
                    switch (sushi)
                    {
                        case "sashimi": sushiPrice = 5.49; break;
                        case "maki": sushiPrice = 4.69; break;
                        case "uramaki": sushiPrice = 4.49; break;
                        case "temaki": sushiPrice = 5.19; break;
                    }
                    break;

                case "Sushi Bar":
                    switch (sushi)
                    {
                        case "sashimi": sushiPrice = 5.25; break;
                        case "maki": sushiPrice = 5.55; break;
                        case "uramaki": sushiPrice = 6.25; break;
                        case "temaki": sushiPrice = 4.75; break;
                    }
                    break;

                case "Asian Pub":
                    switch (sushi)
                    {
                        case "sashimi": sushiPrice = 4.50; break;
                        case "maki": sushiPrice = 4.80; break;
                        case "uramaki": sushiPrice = 5.50; break;
                        case "temaki": sushiPrice = 5.50; break;
                    }
                    break;

                default:
                    Console.WriteLine($"{restaurant} is invalid restaurant!");
                    break;
            }

            double totalPrice = orders * sushiPrice;

            if (restaurant == "Sushi Zone" || restaurant == "Sushi Time" || restaurant == "Sushi Bar" || restaurant == "Asian Pub")
            {

                if (typeOfOrder == 'Y')
                {
                    double price = Math.Ceiling(totalPrice + totalPrice * 0.20);
                    Console.WriteLine($"Total price: {price} lv.");
                }
                else if (typeOfOrder == 'N')
                {
                    double price = Math.Ceiling(totalPrice);
                    Console.WriteLine($"Total price: {price} lv.");
                }
            }
        }
    }
}
