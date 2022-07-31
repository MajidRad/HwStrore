using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations;

public partial class AddingImageProduct4 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Images_Products_productId",
            table: "Images");

        migrationBuilder.DropForeignKey(
            name: "FK_Specifications_Products_productId",
            table: "Specifications");

        migrationBuilder.RenameColumn(
            name: "productId",
            table: "Specifications",
            newName: "ProductId");

        migrationBuilder.RenameIndex(
            name: "IX_Specifications_productId",
            table: "Specifications",
            newName: "IX_Specifications_ProductId");

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

        migrationBuilder.AddForeignKey(
            name: "FK_Specifications_Products_ProductId",
            table: "Specifications",
            column: "ProductId",
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Images_Products_ProductId",
            table: "Images");

        migrationBuilder.DropForeignKey(
            name: "FK_Specifications_Products_ProductId",
            table: "Specifications");

        migrationBuilder.RenameColumn(
            name: "ProductId",
            table: "Specifications",
            newName: "productId");

        migrationBuilder.RenameIndex(
            name: "IX_Specifications_ProductId",
            table: "Specifications",
            newName: "IX_Specifications_productId");

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

        migrationBuilder.AddForeignKey(
            name: "FK_Specifications_Products_productId",
            table: "Specifications",
            column: "productId",
            principalTable: "Products",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
