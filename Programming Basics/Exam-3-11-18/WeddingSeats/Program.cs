using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char posledenSektor = char.Parse(Console.ReadLine());
            int redove = int.Parse(Console.ReadLine());
            int mesta = int.Parse(Console.ReadLine());
            int allMesta = 0;
            int counter = 0;

            for (char i = 'A'; i <= posledenSektor; i++)
            {
                

                for (int j = 1; j <= redove; j++)
                {
                    if (j % 2 == 0)
                    {
                        allMesta = mesta + 2;
                    }
                    else
                    {
                        allMesta = mesta;
                    }
                    

                    for (char k = 'a'; k < 'a' + allMesta; k++)
                    {
                       

                            Console.WriteLine($"{i}{j}{k}");
                            counter++;
                      
                    }

                    

                }
                redove += 1;

            }

            Console.WriteLine(counter);

        }
    }
}
