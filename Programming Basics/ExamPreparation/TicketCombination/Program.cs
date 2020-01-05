using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (char a = 'B'; a <= 'L'; a ++)
            {
                for (char b = 'f'; b >= 'a'; b--)
                    {
                        for (char c = 'A'; c <= 'C'; c++)
                        {
                            for (int d = 1; d <= 10; d++)
                            {
                                for (int e = 10; e >= 1; e--)
                                {
                                if (a % 2 == 0)
                                {
                                    counter++;
                                }
                                
                                if (counter == n )
                                {
                                    Console.WriteLine($"Ticket combination: {a}{b}{c}{d}{e}");
                                    Console.WriteLine($"Prize: " + (a + b +c + d + e) + " lv.");
                                }
                                    
                                }
                            }
                        }
                    }
                    
            }
        }
    }
}
