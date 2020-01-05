using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            //  int n = int.Parse(number[i].ToString());
            int position1 = int. Parse(num[num.Length - 1].ToString);
            int position2 = num[num.Length - 2] - 48;
            int position3 = num[num.Length - 3] - 48;

            for (int i = 1; i <= position1; i++)
            {
                for (int j = 1; j <= position2; j++)
                {
                    for (int k = 1; k <= position3; k++)
                    {
                        int result = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {result};");
                    }

                }

            }
        }
    }
}
