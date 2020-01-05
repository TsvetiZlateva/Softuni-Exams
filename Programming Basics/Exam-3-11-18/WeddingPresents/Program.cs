using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            double guests = double.Parse(Console.ReadLine());
            double presents = double.Parse(Console.ReadLine());
            double counter1 = 0;
            double counter2 = 0;
            double counter3 = 0;
            double counter4 = 0;
            double percentA = 0;
            double percentB = 0;
            double percentV = 0;
            double percentG = 0;
            double percentPresentsToGuests = 0;

            for (int i = 0; i < presents; i++)
            {
                string category = Console.ReadLine();

                if (category == "A")
                {
                    counter1++;
                }
                else if (category == "B")
                {
                    counter2++;
                }
                else if (category == "V")
                {
                    counter3++;
                }
                else if (category == "G")
                {
                    counter4++;
                }
            }

            percentA = counter1 / presents * 100;
            percentB = counter2 / presents * 100;
            percentV = counter3 / presents * 100;
            percentG = counter4 / presents * 100;
            percentPresentsToGuests = presents / guests * 100;

            Console.WriteLine($"{percentA:f2}%");
            Console.WriteLine($"{percentB:f2}%");
            Console.WriteLine($"{percentV:f2}%");
            Console.WriteLine($"{percentG:f2}%");
            Console.WriteLine($"{percentPresentsToGuests:f2}%");

        }
    }
}
