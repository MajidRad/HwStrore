using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations
{
    public partial class AddingImageProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "Path", "ProductId" },
                values: new object[,]
                {
                    { 1, "6800XT", "images/product/6800XT-1", 1 },
                    { 2, "6700XT", "images/product/6700XT-1", 1 },
                    { 3, "RTX 3070", "images/product/RTX-3070-1", 1 },
                    { 4, "5800X", "images/product/5800X-1", 1 },
                    { 5, "5700X", "images/product/5700X-1", 1 },
                    { 6, "12700K", "images/product/12700K-1", 1 },
                    { 7, "11900K", "images/product/11900K-1", 1 },
                    { 8, "Vengeance", "images/product/Vengeance-1", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
