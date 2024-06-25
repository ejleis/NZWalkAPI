using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9293e06f-aabf-43cb-ab68-6a77993e9c31"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dea2765b-0615-424c-893e-2e8c641f67bb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("eb545b25-eef2-497b-a9fc-97f6c2c33d1e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2ffec626-0597-4ab4-9e59-a86a10ba747c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3e802d85-d697-4b6b-b328-6a4abdb4ba5c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8e93ba8f-3443-4407-8793-c3fcd711fb19"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9293e06f-aabf-43cb-ab68-6a77993e9c31"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("aca67d14-f29b-406b-95f6-adf3b2434e65"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b24f4635-a232-4032-af5a-ac8bbc685bd2"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25ebfa42-c9e9-4d9d-a623-56cbd2573e8b"), "Easy" },
                    { new Guid("3c1f94fb-81a4-4785-9539-1ae55bd5d73c"), "Medium" },
                    { new Guid("e118966a-46de-4bba-b98c-754789a1be75"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("4129e070-0249-482f-8c89-4fc30e51b5da"), "ML", "Malaysia", "" },
                    { new Guid("68df36e1-4a09-4ef2-8c00-b89af1035101"), "PH", "Philippines", "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("9bf12e1a-0c17-451e-9add-1ce1e61c44ba"), "WGN", "Wellington", "" },
                    { new Guid("a9c45d46-7223-4ba0-b0e4-4004e6ce9cbb"), "AKL", "Auckland", "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("be6359c1-afea-474e-9d6b-b4ace405257e"), "NTL", "Northland", "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("c282964b-f02b-4e06-a623-08277c2a30e0"), "SG", "Singapore", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("25ebfa42-c9e9-4d9d-a623-56cbd2573e8b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3c1f94fb-81a4-4785-9539-1ae55bd5d73c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e118966a-46de-4bba-b98c-754789a1be75"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4129e070-0249-482f-8c89-4fc30e51b5da"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("68df36e1-4a09-4ef2-8c00-b89af1035101"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9bf12e1a-0c17-451e-9add-1ce1e61c44ba"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a9c45d46-7223-4ba0-b0e4-4004e6ce9cbb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("be6359c1-afea-474e-9d6b-b4ace405257e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c282964b-f02b-4e06-a623-08277c2a30e0"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9293e06f-aabf-43cb-ab68-6a77993e9c31"), "Hard" },
                    { new Guid("dea2765b-0615-424c-893e-2e8c641f67bb"), "Easy" },
                    { new Guid("eb545b25-eef2-497b-a9fc-97f6c2c33d1e"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2ffec626-0597-4ab4-9e59-a86a10ba747c"), "NTL", "Northland", "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("3e802d85-d697-4b6b-b328-6a4abdb4ba5c"), "ML", "Malaysia", "" },
                    { new Guid("8e93ba8f-3443-4407-8793-c3fcd711fb19"), "WGN", "Wellington", "" },
                    { new Guid("9293e06f-aabf-43cb-ab68-6a77993e9c31"), "AKL", "Auckland", "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("aca67d14-f29b-406b-95f6-adf3b2434e65"), "PH", "Philippines", "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("b24f4635-a232-4032-af5a-ac8bbc685bd2"), "SG", "Singapore", "" }
                });
        }
    }
}
