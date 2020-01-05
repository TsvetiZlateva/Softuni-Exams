using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string item = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            double itemPrice = 0;

            switch (team)
            {
                case "Argentina":

                    switch (item)
                    {
                        case "flags": itemPrice = 3.25; break;
                        case "caps": itemPrice = 7.20; break;
                        case "posters": itemPrice = 5.10; break;
                        case "stickers": itemPrice = 1.25; break;
                        default: Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;

                case "Brazil":
                    switch (item)
                    {
                        case "flags": itemPrice = 4.20; break;
                        case "caps": itemPrice = 8.50; break;
                        case "posters": itemPrice = 5.35; break;
                        case "stickers": itemPrice = 1.20; break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;

                case "Croatia":
                    switch (item)
                    {
                        case "flags": itemPrice = 2.75; break;
                        case "caps": itemPrice = 6.90; break;
                        case "posters": itemPrice = 4.95; break;
                        case "stickers": itemPrice = 1.10; break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;

                case "Denmark":
                    switch (item)
                    {
                        case "flags": itemPrice = 3.10; break;
                        case "caps": itemPrice = 6.50; break;
                        case "posters": itemPrice = 4.80; break;
                        case "stickers": itemPrice = 0.90; break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid country!");
                    break;
            }

            double totalMoneySpent = itemPrice * num;

            if ((team == "Argentina" || team == "Brazil" || team == "Croatia" || team == "Denmark") && (item == "flags" || item == "caps" || item == "posters" || item == "stickers"))
            {
                Console.WriteLine($"Pepi bought {num} {item} of {team} for {totalMoneySpent:F2} lv.");
            }
            
        }
    }
}
