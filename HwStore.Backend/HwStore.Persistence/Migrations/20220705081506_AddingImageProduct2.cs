using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations
{
    public partial class AddingImageProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Images",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                newName: "IX_Images_productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_productId",
                table: "Images",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_productId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Images",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_productId",
                table: "Images",
                newName: "IX_Images_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
