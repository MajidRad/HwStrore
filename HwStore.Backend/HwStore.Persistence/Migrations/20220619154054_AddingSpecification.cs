using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HwStore.Persistence.Migrations
{
    public partial class AddingSpecification : Migration
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
                    BrandId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Products_productId",
                        column: x => x.productId,
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
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 3, "Get the ultimate game changer. AMD Radeon™ RX 6800 XT graphics card features breakthrough AMD RDNA™ 2 architecture. ", "6800XT", 800m, 3 },
                    { 2, 1, 3, "Get the ultimate game changer. AMD Radeon™ RX 6700 XT graphics card features breakthrough AMD RDNA™ 2 architecture. ", "6700XT", 700m, 2 },
                    { 3, 3, 3, "The GeForce RTX™ 3070 is powered by Ampere—NVIDIA's 2nd gen RTX architecture.", "RTX 3070", 850m, 2 },
                    { 4, 2, 1, "AMD Ryzen 7 5800X - Ryzen 7 5000 Series Vermeer (Zen 3) 8-Core 3.8 GHz Socket AM4 105W Desktop Processor ", "Ryzen 7 5800X", 500m, 4 },
                    { 5, 1, 1, "AMD Ryzen 7 5700X - Ryzen 7 5000 Series Vermeer (Zen 3) 8-Core 3.4 GHz Socket AM4 105W Desktop Processor -", "Ryzen 7 5700X", 400m, 5 },
                    { 6, 2, 1, "Intel Core i7-12700K - Core i7 12th Gen Alder Lake 12-Core (8P+4E) 3.6 GHz LGA 1700 125W Intel UHD Graphics 770", "12700K", 450m, 5 },
                    { 7, 2, 1, "Intel Core i9-11900K - Core i9 11th Gen Rocket Lake 8-Core 3.5 GHz LGA 1200 125W Intel UHD Graphics 750 Desktop Processor ", "11900K", 450m, 2 },
                    { 8, 4, 2, "Vengeance RGB Pro 16GB (2 x 8GB) Timing: 16-18-18-36  ", "Vengeance RGB Pro", 100m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "SpecLabel", "SpecValue", "productId" },
                values: new object[,]
                {
                    { 1, "INTERFACE", "PCI Express® Gen 4", 1 },
                    { 2, "CORES", "4608 Units", 1 },
                    { 3, "CORE CLOCKS", "Boost: Up to 2310 MHz / Game: Up to 2065 MHz", 1 },
                    { 4, "MEMORY SPEED", "16 Gbps", 1 },
                    { 5, "MEMORY ", "16GB GDDR6", 1 },
                    { 6, "MEMORY BUS", "256-bit", 1 },
                    { 7, "OUTPUT", "DisplayPort x 3 (v1.4)", 1 },
                    { 8, "POWER CONNECTORS", "300 W", 1 },
                    { 9, "INTERFACE", "PCI Express® Gen 4", 2 },
                    { 10, "CORES", "2560 Units", 2 },
                    { 11, "CORE CLOCKS", "Boost: Up to 2620 MHz / Game: Up to 2474 MHz", 2 },
                    { 12, "MEMORY SPEED", "16 Gbps", 2 },
                    { 13, "MEMORY ", "12GB GDDR6", 2 },
                    { 14, "MEMORY BUS", "192-bit", 2 },
                    { 15, "OUTPUT", "DisplayPort x 3 (v1.4)", 2 },
                    { 16, "POWER CONNECTORS", "230 W", 3 },
                    { 17, "INTERFACE", "PCI Express® Gen 4", 3 },
                    { 18, "CORES", "5888 Units", 3 },
                    { 19, "CORE CLOCKS", "Boost:Boost: 1845 MHz", 3 },
                    { 20, "MEMORY SPEED", "14 Gbps", 3 },
                    { 21, "MEMORY ", "8GB GDDR6", 3 },
                    { 22, "MEMORY BUS", "256-bit", 3 },
                    { 23, "OUTPUT", "DisplayPort x 3 (v1.4) / HDMI x 1 (Supports 4K@120Hz as specified in HDMI 2.1)", 3 },
                    { 24, "POWER CONNECTORS", "240W", 3 },
                    { 25, "Series", "Ryzen 7 5000 Series", 4 },
                    { 26, "CPU Socket Type ", "Socket AM4", 4 },
                    { 27, "# of Cores ", "8-Core", 4 },
                    { 28, "# of Threads ", "16", 4 },
                    { 29, "Operating Frequency  ", "3.8 GHz", 4 },
                    { 30, "Max Turbo Frequency ", "4.7 GHz", 4 },
                    { 31, "L2 Cache ", "4MB", 4 },
                    { 32, "L3 Cache ", "32MB", 4 },
                    { 33, "Manufacturing Tech ", "7nm", 4 },
                    { 34, "Memory Types", "DDR4 3200", 4 },
                    { 35, "Thermal Design Power ", "105W", 4 },
                    { 36, "Series", "Ryzen 7 5000 Series", 5 },
                    { 37, "# of Cores ", "8-Core", 5 },
                    { 38, "# of Threads ", "16", 5 },
                    { 39, "Operating Frequency  ", "3.3 GHz", 5 },
                    { 40, "Max Turbo Frequency ", "4.3 GHz", 5 },
                    { 41, "L2 Cache ", "4MB", 5 },
                    { 42, "L3 Cache ", "32MB", 5 }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "SpecLabel", "SpecValue", "productId" },
                values: new object[,]
                {
                    { 43, "Manufacturing Tech ", "7nm", 5 },
                    { 44, "Memory Types", "DDR4 3200", 5 },
                    { 45, "Thermal Design Power ", "105W", 5 },
                    { 46, "Series", "Core i7 12th Gen", 6 },
                    { 47, "CPU Socket Type", "LGA 1700", 6 },
                    { 48, "Core Name", "Alder Lake", 6 },
                    { 49, "# of Cores ", "12-Core (8P+4E)", 6 },
                    { 50, "# of Threads ", "20", 6 },
                    { 51, "Operating Frequency  ", "3.6 GHz", 6 },
                    { 52, "Max Turbo Frequency ", "Up to 4.9 GHz", 6 },
                    { 53, "L2 Cache ", "12MB", 6 },
                    { 54, "L3 Cache ", "25MB", 6 },
                    { 55, "Manufacturing Tech ", "Intel 7", 6 },
                    { 56, "Memory Types", "DDR4 3200 / DDR5 4800", 6 },
                    { 57, "Thermal Design Power ", "190W", 6 },
                    { 58, "Series", "Core i7 11th Gen", 7 },
                    { 59, "CPU Socket Type", "LGA 1700", 7 },
                    { 60, "Core Name", "Alder Lake", 7 },
                    { 61, "# of Cores ", "12-Core", 7 },
                    { 62, "# of Threads ", "24", 7 },
                    { 63, "Operating Frequency  ", "3.6 GHz", 7 },
                    { 64, "Max Turbo Frequency ", "Up to 4.9 GHz", 7 },
                    { 65, "L2 Cache ", "12MB", 7 },
                    { 66, "L3 Cache ", "25MB", 7 },
                    { 67, "Manufacturing Tech ", "Intel 7", 7 },
                    { 68, "Memory Types", "DDR4 3200 ", 7 },
                    { 69, "Thermal Design Power ", "190W", 7 },
                    { 70, "Capacity", "16GB (2 x 8GB)", 8 },
                    { 71, "Type", "288-Pin DDR4 SDRAM", 8 },
                    { 72, "Speed ", "DDR4 3200 (PC4 25600)", 8 },
                    { 73, "CAS Latency ", "16", 8 },
                    { 74, "Timing", "16-18-18-36", 8 },
                    { 75, "Voltage ", "1.35V", 8 },
                    { 76, "Chipset", "Intel XMP 2.0", 8 },
                    { 77, "Color", "Black", 8 },
                    { 78, "Heat Spreader", "Anodized Aluminum", 8 },
                    { 79, "CPU Socket Type ", "Socket AM4", 5 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_productId",
                table: "Specifications",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
