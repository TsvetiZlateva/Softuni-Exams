using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double spaceShipWidth = double.Parse(Console.ReadLine());
            double spaceShipLenght = double.Parse(Console.ReadLine());
            double spaceShipHeight = double.Parse(Console.ReadLine());
            double astronautMidHeight = double.Parse(Console.ReadLine());

            double spaceShipVolume = spaceShipWidth * spaceShipLenght * spaceShipHeight;
            double astronautNeededSpace = 2 * 2 * (astronautMidHeight + 0.40);

            double holdedAstronauts = Math.Floor(spaceShipVolume / astronautNeededSpace);

            if (holdedAstronauts >= 3 && holdedAstronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {holdedAstronauts} astronauts.");
            }
            else if (holdedAstronauts < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (holdedAstronauts > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
