using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetWithDB;
using Microsoft.SqlServer.Server;

namespace AssetWithDB
{
    internal class AddDevices
    {
        public static Device AddDevice()
        {

            MyDbContext Context = new MyDbContext();

            List<Device> Devices = Context.Devices.ToList();
            Device Device1 = new Device();
            
            Console.Write("Enter a new device type (Press (1) to add a Phone and (2) to add a Computer): ", Console.ForegroundColor = ConsoleColor.Yellow);
            string TypeOfDevice="";
            string Chosing = Console.ReadLine();
            switch (Chosing)
            {
                case "1":
                    TypeOfDevice = "Phone";
                    break;
                case "2":
                    TypeOfDevice = "Computer";
                    break;
              
                default: // if the user press any other number the app will show an error message and re ask the user for input
                    Console.WriteLine("Wrong input, Re-Input the values\n", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                    break;
            }
           

            Console.Write("Enter the brand name: ");
            string Brand = Console.ReadLine();

            Console.Write("Enter the model: ");
            string Model = Console.ReadLine();

            Console.WriteLine("Chose the office. Please chose a number: ");
            Console.WriteLine("-1) Stockholm. \n -2) Berlin\n -3) New York ");
            string Office = "";
            string Chosing2 = Console.ReadLine();
            switch (Chosing2)
            {
                case "1":
                    Office = "Stockholm";
                    break;
                case "2":
                    Office = "Berlin";
                    break;
                case "3":
                    Office = "New York";
                    break;

                default: 
                    Console.WriteLine("Wrong input, Re-Input the values\n", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                    break;
            }

            Console.Write("Enter the purchase date: ");                          
            DateTime PurchaseDate;
            while (!DateTime.TryParse(Console.ReadLine(),System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,out PurchaseDate))
            {
                Console.WriteLine("Your input is incorrect. Please input again.", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }

            while (PurchaseDate < DateTime.Now.AddYears(-3))
            {
                // if the date is more than 3 years ago from now show error to the user
                while (!DateTime.TryParse(Console.ReadLine(),System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,out PurchaseDate))
                {
                   Console.WriteLine("The date is more than 3 years ago please write the date again", Console.ForegroundColor = ConsoleColor.Red);
                   Console.ResetColor();                
                }
            }

            Console.Write("Enter the price in USD: ");
            int Price;
            double LocalPrice = 0; 

            while (!int.TryParse(Console.ReadLine(), out Price)) // read the price and make sure the input is a number 
            {
                Console.WriteLine("Please enter a valid number\n", Console.ForegroundColor = ConsoleColor.Red);  // if not a number ask for a valid number
                Console.ResetColor();
            }

            Console.WriteLine("Write the currency you want to convert to \n- 1) EUR\n- 2) SEK\n-3) If you want to keep the price in USD");
            string Currency = Console.ReadLine();
            switch (Currency)
            {
                case "1":
                    Currency = "EUR";
                    break;
                case "2":
                    Currency = "SEK";
                    break;
                case "3":
                    Currency = "USD";
                    break;
                default: 
                    Console.WriteLine("Wrong input, Re-Input the values\n", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();

                    break;
            }
            if (Currency == "USD")
            {
               LocalPrice = Price * 1;          
            }       
            if (Currency == "EUR")
            {
                LocalPrice = Price * 0.9;
            }
            else if (Currency == "SEK")
            {
                LocalPrice = (Price * 10);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product was succesfully added ");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

            Device1.TypeOfDevice = TypeOfDevice;
            Device1.Brand = Brand;
            Device1.Model = Model;
            Device1.Office = Office;
            Device1.PurchaseDate = PurchaseDate;
            Device1.Price = Price;
            Device1.Currency = Currency;
            Device1.LocalPrice = LocalPrice;

            return Device1;
        }
       
      

    }
}
