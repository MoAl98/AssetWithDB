using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetWithDB
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "data source=HAMODA;initial catalog=master;Database=Asset;trusted_connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true";
        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<Device>().HasData(new Device
            {
                Id = 1,
                TypeOfDevice = "Computer",
                Brand = "HP",
                Model = "Elite Dragonfly G2",
                Office = "Stockholm",
                PurchaseDate = new DateTime(2021, 12, 1),
                Price = 9000,
                Currency = "SEK",
                LocalPrice = 1000
            });

            ModelBuilder.Entity<Device>().HasData(new Device
            {
                Id = 2,
                TypeOfDevice = "Phone",
                Brand = "Iphone",
                Model = "13 pro max",
                Office = "Berlin",
                PurchaseDate = new DateTime(2021, 08, 1),
                Price = 13000,
                Currency = "EUR",
                LocalPrice = 1300
            });

            ModelBuilder.Entity<Device>().HasData(new Device{ Id = 3,
                TypeOfDevice = "Phone",
                Brand = "Samsung",
                Model = "S22",
                Office = "New York",
                PurchaseDate = new DateTime(2022, 01, 11),
                Price = 11000,
                Currency = "SEK",
                LocalPrice = 11000
            });




        }


    }
}
