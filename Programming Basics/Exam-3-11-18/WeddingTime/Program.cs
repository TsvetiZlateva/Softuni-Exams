using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double shampain = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());

            double shampainPrice = whiskeyPrice * 0.50;
            double winePrice = shampainPrice * 0.40;
            double waterPrice = shampainPrice * 0.10;

            double money = whiskey * whiskeyPrice + water * waterPrice + wine * winePrice + shampain * shampainPrice;

            Console.WriteLine($"{money:f2}");
        }
    }
}
