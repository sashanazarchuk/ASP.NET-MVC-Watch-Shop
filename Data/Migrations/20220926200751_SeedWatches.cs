using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SeedWatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "Brand", "Guarantee", "Material", "Model", "Price", "img" },
                values: new object[,]
                {
                    { 1, "Rolex", "3 years", "Steel 904L", "Air-King", 7400m, "/Images/Rolex Air-King.png" },
                    { 2, "Rolex", "3 years", "Stainless Steel", "Datejust", 7800m, "/Images/Rolex Datejust.png" },
                    { 3, "Rolex", "4 years", "18-carat Everose gold", "Yacht-Master", 47150m, "/Images/Rolex Yacht-Master.png" },
                    { 4, "Rolex", "5 years", "Stainless Steel, Yellow Gold 18k", "Sea-Dweller", 23500m, "/Images/Rolex Sea-Dweller.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
