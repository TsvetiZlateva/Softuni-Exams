using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int guests = 0;
            double couvert = 0;
            double sum = 0;

            while (input != "The restaurant is full")
            {
                int people = int.Parse(input.ToString());

                if (people < 5)
                {
                    couvert = people * 100;
                }
                else if (people >= 5)
                {
                    couvert = people * 70;
                }

                sum += couvert;
                guests += people;

                input = Console.ReadLine();

                if (input == "The restaurant is full")
                {
                    break;
                }
            }

            double diff = Math.Abs(sum - buget);

            if (sum >= buget)
            {
                Console.WriteLine($"You have {guests} guests and {diff} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {guests} guests and {sum} leva income, but no singer.");
            }
        }
    }
}
