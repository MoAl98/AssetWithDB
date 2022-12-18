using AssetWithDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetWithDB
{
    internal class PrintDevices
    {
        public static void PrintDevicesSorted(List<Device> inputs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID".PadRight(10) + "Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(20) + "Office".PadRight(10) + "Purchase Date".PadRight(20) + "Price in USD".PadRight(15) + "Currency".PadRight(10) + "Local price today");
            Console.ResetColor();
            List<Device> sortedPrice = inputs.OrderBy(inputs => inputs.Office).ThenBy(inputs => inputs.PurchaseDate).ToList(); //sort the list

            foreach (Device input in sortedPrice)
            {

                if (input.PurchaseDate < DateTime.Now.AddMonths(-33) && input.PurchaseDate < DateTime.Now.AddMonths(-30) && input.PurchaseDate > DateTime.Now.AddMonths(-36))//check if the purchase date is less than 3 months and less than 3 years
                {
                    Console.ForegroundColor = ConsoleColor.Red;//print red if this conndition is true
                    Console.WriteLine(input.Print());//call the method print from Device class


                }
                else if (input.PurchaseDate < DateTime.Now.AddMonths(-30) && input.PurchaseDate > DateTime.Now.AddMonths(-36))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(input.Print());

                }
                else
                {
                    Console.WriteLine(input.Print());

                }
                Console.ResetColor();
            }


        }


    }
}
