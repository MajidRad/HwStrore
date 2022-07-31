using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations;

public partial class AddingImageProduct3 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 2,
            column: "productId",
            value: 2);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 3,
            column: "productId",
            value: 3);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 4,
            column: "productId",
            value: 4);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 5,
            column: "productId",
            value: 5);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 6,
            column: "productId",
            value: 6);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 7,
            column: "productId",
            value: 7);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 8,
            column: "productId",
            value: 8);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 2,
            column: "productId",
            value: 1);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 3,
            column: "productId",
            value: 1);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 4,
            column: "productId",
            value: 1);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 5,
            column: "productId",
            value: 1);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 6,
            column: "productId",
            value: 1);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 7,
            column: "productId",
            value: 1);

        migrationBuilder.UpdateData(
            table: "Images",
            keyColumn: "Id",
            keyValue: 8,
            column: "productId",
            value: 1);
    }
}
