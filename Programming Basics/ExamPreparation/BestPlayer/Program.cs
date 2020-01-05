using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
           
            int max = int.MinValue;
            string bestPlayer = "";

            while (name != "END")
            {
                

                int goals = int.Parse(Console.ReadLine());

                if (goals > max)
                {
                    max = goals;
                    bestPlayer = name;
                }
                
                if (goals >= 10)
                {
                    break;
                }

                name = Console.ReadLine();
                if (name == "END")
                {
                    break;
                }
                
            }


            Console.WriteLine($"{bestPlayer} is the best player!");
          

            if (max >= 3)
            {
                Console.WriteLine($"He has scored {max} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {max} goals.");
            }

        }
    }
}
