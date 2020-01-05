using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnBussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string n = Console.ReadLine();
            int room = width * lenght * height;
            int pcVolume = 0;

            while (n != "Done")
            {
                int pc = int.Parse(n.ToString());
                pcVolume += pc;

                if (pcVolume > room)
                {
                    break;
                }

                n = Console.ReadLine();
            }

            int difference = Math.Abs(room - pcVolume);

            if (n == "Done")
            {
                Console.WriteLine($"{difference} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {difference} Cubic meters more.");
            }
            
        }
    }
}
