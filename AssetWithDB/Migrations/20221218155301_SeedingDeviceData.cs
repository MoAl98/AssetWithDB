using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetWithDB.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDeviceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Brand", "Currency", "LocalPrice", "Model", "Office", "Price", "PurchaseDate", "TypeOfDevice" },
                values: new object[,]
                {
                    { 1, "HP", "SEK", 1000.0, "Elite Dragonfly G2", "Stockholm", 9000, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 2, "Iphone", "EUR", 1300.0, "13 pro max", "Berlin", 13000, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 3, "Samsung", "SEK", 11000.0, "S22", "New York", 11000, new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
