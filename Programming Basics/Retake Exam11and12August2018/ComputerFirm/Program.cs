using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerFirm
{
    class Program
    {
        static void Main(string[] args)
        {
            int pc = int.Parse(Console.ReadLine());
            double realSales = 0;
            double ratingAll = 0;
            double allSales = 0;

            for (int i = 1; i <= pc; i++)
            {
                int num = int.Parse(Console.ReadLine());
                double rating = num % 10;
                double sales = num / 10;

                switch (rating)
                {
                    case 2: realSales = 0; break;
                    case 3: realSales = sales * 0.50; break;
                    case 4: realSales = sales * 0.70; break;
                    case 5: realSales = sales * 0.85; break;
                    case 6: realSales = sales; break;

                }

                ratingAll += rating;
                allSales += realSales;

            }

           
            double midRating = ratingAll / pc;
            Console.WriteLine($"{allSales:f2}");
            Console.WriteLine($"{midRating:f2}");
        }
    }
}
