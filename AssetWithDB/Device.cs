using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetWithDB
{
    internal class Device
    {
        public Device()
        {
        }

        public Device(int id, string typeOfDevice, string brand, string model, string office, DateTime purchaseDate, int price, string currency, int localPrice)
        {
            Id = id;
            TypeOfDevice = typeOfDevice;
            Brand = brand;
            Model = model;
            Office = office;
            PurchaseDate = purchaseDate;
            Price = price;
            Currency = currency;
            LocalPrice = localPrice;
        }
        public int Id { get; set; }
        public string TypeOfDevice { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Office { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public double LocalPrice { get; set; }

        public string Print()
        {

         return this.Id.ToString().PadRight(10) + this.TypeOfDevice.PadRight(10) + this.Brand.PadRight(10) + this.Model.PadRight(20) + this.Office.PadRight(10)
         + this.PurchaseDate.ToString("yyyy-MM-dd").PadRight(20) + this.Price.ToString().PadRight(15) + this.Currency.PadRight(10) + this.LocalPrice.ToString().PadRight(10);

        }

    }

}
