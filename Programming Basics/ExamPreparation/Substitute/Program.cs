using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int a = k; a <= 8; a++)
            {
                for (int b = 9; b >= l; b--)
                {
                    for (int c = m; c <= 8; c++)
                    {
                        for (int d = 9; d >= n; d--)
                        {
                            if (a % 2 == 0 && b % 2 != 0 && c % 2 == 0 && d % 2 != 0)
                            {
                                if (a == c && b == d)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{a}{b} - {c}{d}");
                                    counter++;
                                }
                            }
                            
                            if (counter == 6)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
