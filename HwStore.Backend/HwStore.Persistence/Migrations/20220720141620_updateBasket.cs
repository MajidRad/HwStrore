using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations
{
    public partial class updateBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BasketItem",
                newName: "QuantityInBasket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityInBasket",
                table: "BasketItem",
                newName: "Quantity");
        }
    }
}
