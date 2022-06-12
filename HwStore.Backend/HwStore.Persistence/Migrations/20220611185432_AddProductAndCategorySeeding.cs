using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations
{
    public partial class AddProductAndCategorySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amd" },
                    { 2, "Intel" },
                    { 3, "Nvidia" },
                    { 4, "CorsAir" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Cpu", 1 },
                    { 2, "Ram", 1 },
                    { 3, "Vga", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "DetailId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 3, "Get the ultimate game changer. AMD Radeon™ RX 6800 XT graphics card features breakthrough AMD RDNA™ 2 architecture. ", 0, "6800XT", 800m, 3 },
                    { 2, 1, 3, "Get the ultimate game changer. AMD Radeon™ RX 6700 XT graphics card features breakthrough AMD RDNA™ 2 architecture. ", 0, "6700XT", 700m, 2 },
                    { 3, 3, 3, "The GeForce RTX™ 3070 is powered by Ampere—NVIDIA's 2nd gen RTX architecture.", 0, "RTX 3070", 850m, 2 },
                    { 4, 2, 1, "AMD Ryzen 7 5800X - Ryzen 7 5000 Series Vermeer (Zen 3) 8-Core 3.8 GHz Socket AM4 105W Desktop Processor ", 0, "Ryzen 7 5800X", 500m, 4 },
                    { 5, 1, 1, "AMD Ryzen 7 5700X - Ryzen 7 5000 Series Vermeer (Zen 3) 8-Core 3.4 GHz Socket AM4 105W Desktop Processor -", 0, "Ryzen 7 5700X", 400m, 5 },
                    { 6, 2, 1, "Intel Core i7-12700K - Core i7 12th Gen Alder Lake 12-Core (8P+4E) 3.6 GHz LGA 1700 125W Intel UHD Graphics 770", 0, "12700K", 450m, 5 },
                    { 7, 2, 1, "Intel Core i9-11900K - Core i9 11th Gen Rocket Lake 8-Core 3.5 GHz LGA 1200 125W Intel UHD Graphics 750 Desktop Processor ", 0, "11900K", 450m, 2 },
                    { 8, 4, 2, "Vengeance RGB Pro 16GB (2 x 8GB) Timing: 16-18-18-36  ", 0, "Vengeance RGB Pro", 100m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductId1",
                table: "Details",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
