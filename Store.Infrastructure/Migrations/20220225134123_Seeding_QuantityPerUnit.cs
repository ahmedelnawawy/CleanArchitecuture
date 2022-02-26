using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Infrastructure.Migrations
{
    public partial class Seeding_QuantityPerUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuantityPerUnits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kilo" },
                    { 2, "box" },
                    { 3, "can" },
                    { 4, "liter" },
                    { 5, "bottle" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuantityPerUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuantityPerUnits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuantityPerUnits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuantityPerUnits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuantityPerUnits",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
