using AssetWithDB;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.InteropServices;

Console.WriteLine("Welcome to the Asset App", Console.ForegroundColor = ConsoleColor.Yellow);
Console.ResetColor();


MyDbContext Context = new MyDbContext();


while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Choose a number: ");
    Console.WriteLine("1. List all Details.\t\t2. Add a new Item\n");
    Console.WriteLine("3. Edit an Item.\t\t4. Delete an Item\n");
    Console.WriteLine("5. Exit application");
    Console.Write("Make your choice: ");
    Console.ResetColor();
    string UserChoice = Console.ReadLine();

    if (UserChoice == "1")
    {
        List<Device> Devices = Context.Devices.ToList();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All the items in the database.\n");
        Console.ForegroundColor = ConsoleColor.Yellow;

        PrintDevices.PrintDevicesSorted(Devices);
        Console.WriteLine();

    }

    else if (UserChoice == "2")
    {
        List<Device> Devices = Context.Devices.ToList();
        Device Device1 = new Device();

        Device Device2 = AddDevices.AddDevice();

        Context.Devices.Add(Device2);
        Context.SaveChanges();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The information was saved.\n");
        Console.ResetColor();

    }

    else if (UserChoice == "3")
    {
        Console.WriteLine("Choose an Item to edit.");
        List<Device> Devices = Context.Devices.ToList();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All the items in the database.\n");
        Console.ResetColor();
        PrintDevices.PrintDevicesSorted(Devices);

        Console.Write("Choose an Item to edit: ");
        string EditItem = Console.ReadLine();
        Device ItemToEdit = Context.Devices.FirstOrDefault(x => x.Id == Convert.ToInt32(EditItem));
        Console.WriteLine("Enter the new data: ");

        Device Device2 = AddDevices.AddDevice();
        ItemToEdit.TypeOfDevice = Device2.TypeOfDevice;
        ItemToEdit.Brand = Device2.Brand;
        ItemToEdit.Model = Device2.Model;
        ItemToEdit.Office = Device2.Office;
        ItemToEdit.PurchaseDate = Device2.PurchaseDate;
        ItemToEdit.Price = Device2.Price;
        ItemToEdit.Currency = Device2.Currency;
        ItemToEdit.LocalPrice = Device2.LocalPrice;

        Context.Devices.Update(ItemToEdit);
        Context.SaveChanges();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The information is Edited and saved.\n");
        Console.ResetColor();
    }

    else if (UserChoice == "4")
    {
        Console.WriteLine("Choose an item to delete.");
        List<Device> Devices = Context.Devices.ToList();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All the items in the database.\n");
        Console.ForegroundColor = ConsoleColor.Yellow;

        PrintDevices.PrintDevicesSorted(Devices);
        Console.Write("Choose an Item to Delete: ");
        string RemoveItem = Console.ReadLine();
        Device ItemToDelete = Context.Devices.FirstOrDefault(x => x.Id == Convert.ToInt32(RemoveItem));


        Context.Devices.Remove(ItemToDelete);
        Context.SaveChanges();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The new information was saved.\n");
        Console.ResetColor();
    }

    else if (UserChoice == "5")
    {
       
        Console.WriteLine("Good bye!");
        break;
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a number between 1 and 5. Try again!");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

}
   

