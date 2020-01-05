using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int plays = int.Parse(Console.ReadLine());
            int sumVkaraniGolove = 0;
            int sumPolucheniGolove = 0;
            int points = 0;

            for (int i = 0; i < plays; i++)
            {
                int vkaraniGolove = int.Parse(Console.ReadLine());
                int polucheniGolove = int.Parse(Console.ReadLine());

                sumVkaraniGolove += vkaraniGolove;
                sumPolucheniGolove += polucheniGolove;

                if (vkaraniGolove > polucheniGolove)
                {
                    points += 3;
                }
                else if (vkaraniGolove == polucheniGolove)
                {
                    points += 1;
                }
                
            }
            int difference = sumVkaraniGolove - sumPolucheniGolove;

            if (sumVkaraniGolove >= sumPolucheniGolove)
            {
                Console.WriteLine($"{team} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {difference}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {difference}.");
            }
        }
    }
}
