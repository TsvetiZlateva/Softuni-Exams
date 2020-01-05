using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int freeSpace = width * lenght * height;
            int boxesSpace = 0;

            while (input != "Done")
            {
                int numBoxes = int.Parse(input);
                boxesSpace += numBoxes;

                if (boxesSpace > freeSpace)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            int difference = Math.Abs(freeSpace - boxesSpace);

            if (input == "Done")
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
