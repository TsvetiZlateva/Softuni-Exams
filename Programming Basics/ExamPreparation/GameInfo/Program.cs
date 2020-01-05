using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int plays = int.Parse(Console.ReadLine());
            double duration = 0;
            int counter1 = 0;
            int counter2 = 0;

            for (int i = 0; i < plays; i++)
            {
                double min = int.Parse(Console.ReadLine());

                if (min > 90 && min <= 120)
                {
                    counter1++;
                }
                if (min > 120)
                {
                    counter2++;
                }
                duration += min;

            }

            double average = duration / plays;

            Console.WriteLine($"{team} has played {duration} minutes. Average minutes per game: {average:f2}");
            Console.WriteLine($"Games with penalties: {counter2}");
            Console.WriteLine($"Games with additional time: {counter1}");
            
        }
    }
}
