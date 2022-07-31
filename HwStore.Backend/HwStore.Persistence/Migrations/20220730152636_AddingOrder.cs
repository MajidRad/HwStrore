using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations;

public partial class AddingOrder : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                shippingAddress_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                shippingAddress_Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                shippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                shippingAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                DeliveryFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                OrderStatus = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "OrderItem",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ItemOrdered_productId = table.Column<int>(type: "int", nullable: true),
                ItemOrdered_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ItemOrdered_pictrureUrl = table.Column<int>(type: "int", nullable: true),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false),
                OrderId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderItem", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderItem_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_OrderItem_OrderId",
            table: "OrderItem",
            column: "OrderId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OrderItem");

        migrationBuilder.DropTable(
            name: "Orders");
    }
}
