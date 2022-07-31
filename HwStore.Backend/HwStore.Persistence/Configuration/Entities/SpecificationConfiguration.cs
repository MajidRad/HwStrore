using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HwStore.Persistence.Configuration.Entities;

internal class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
{
    public void Configure(EntityTypeBuilder<Specification> builder)
    {
        builder.HasData(
            //Rx 6800xt
            new Specification { Id = 1, SpecLabel = "INTERFACE", SpecValue = "PCI Express® Gen 4", ProductId = 1 },
            new Specification { Id = 2, SpecLabel = "CORES", SpecValue = "4608 Units", ProductId = 1 },
            new Specification { Id = 3, SpecLabel = "CORE CLOCKS", SpecValue = "Boost: Up to 2310 MHz / Game: Up to 2065 MHz", ProductId = 1 },
            new Specification { Id = 4, SpecLabel = "MEMORY SPEED", SpecValue = "16 Gbps", ProductId = 1 },
            new Specification { Id = 5, SpecLabel = "MEMORY ", SpecValue = "16GB GDDR6", ProductId = 1 },
            new Specification { Id = 6, SpecLabel = "MEMORY BUS", SpecValue = "256-bit", ProductId = 1 },
            new Specification { Id = 7, SpecLabel = "OUTPUT", SpecValue = "DisplayPort x 3 (v1.4)", ProductId = 1 },
            new Specification { Id = 8, SpecLabel = "POWER CONNECTORS", SpecValue = "300 W", ProductId = 1 },


            //Rx 6700xt
            new Specification { Id = 9, SpecLabel = "INTERFACE", SpecValue = "PCI Express® Gen 4", ProductId = 2 },
            new Specification { Id = 10, SpecLabel = "CORES", SpecValue = "2560 Units", ProductId = 2 },
            new Specification { Id = 11, SpecLabel = "CORE CLOCKS", SpecValue = "Boost: Up to 2620 MHz / Game: Up to 2474 MHz", ProductId = 2 },
            new Specification { Id = 12, SpecLabel = "MEMORY SPEED", SpecValue = "16 Gbps", ProductId = 2 },
            new Specification { Id = 13, SpecLabel = "MEMORY ", SpecValue = "12GB GDDR6", ProductId = 2 },
            new Specification { Id = 14, SpecLabel = "MEMORY BUS", SpecValue = "192-bit", ProductId = 2 },
            new Specification { Id = 15, SpecLabel = "OUTPUT", SpecValue = "DisplayPort x 3 (v1.4)", ProductId = 2 },
            new Specification { Id = 16, SpecLabel = "POWER CONNECTORS", SpecValue = "230 W", ProductId = 3 },


             //RTX 3070
             new Specification { Id = 17, SpecLabel = "INTERFACE", SpecValue = "PCI Express® Gen 4", ProductId = 3 },
            new Specification { Id = 18, SpecLabel = "CORES", SpecValue = "5888 Units", ProductId = 3 },
            new Specification { Id = 19, SpecLabel = "CORE CLOCKS", SpecValue = "Boost:Boost: 1845 MHz", ProductId = 3 },
            new Specification { Id = 20, SpecLabel = "MEMORY SPEED", SpecValue = "14 Gbps", ProductId = 3 },
            new Specification { Id = 21, SpecLabel = "MEMORY ", SpecValue = "8GB GDDR6", ProductId = 3 },
            new Specification { Id = 22, SpecLabel = "MEMORY BUS", SpecValue = "256-bit", ProductId = 3 },
            new Specification { Id = 23, SpecLabel = "OUTPUT", SpecValue = "DisplayPort x 3 (v1.4) / HDMI x 1 (Supports 4K@120Hz as specified in HDMI 2.1)", ProductId = 3 },
            new Specification { Id = 24, SpecLabel = "POWER CONNECTORS", SpecValue = "240W", ProductId = 3 },

            //Ryzen 7 5800X

            new Specification { Id = 25, SpecLabel = "Series", SpecValue = "Ryzen 7 5000 Series", ProductId = 4 },
             new Specification { Id = 26, SpecLabel = "CPU Socket Type ", SpecValue = "Socket AM4", ProductId = 4 },
            new Specification { Id = 27, SpecLabel = "# of Cores ", SpecValue = "8-Core", ProductId = 4 },
            new Specification { Id = 28, SpecLabel = "# of Threads ", SpecValue = "16", ProductId = 4 },
            new Specification { Id = 29, SpecLabel = "Operating Frequency  ", SpecValue = "3.8 GHz", ProductId = 4 },
            new Specification { Id = 30, SpecLabel = "Max Turbo Frequency ", SpecValue = "4.7 GHz", ProductId = 4 },
            new Specification { Id = 31, SpecLabel = "L2 Cache ", SpecValue = "4MB", ProductId = 4 },
            new Specification { Id = 32, SpecLabel = "L3 Cache ", SpecValue = "32MB", ProductId = 4 },
            new Specification { Id = 33, SpecLabel = "Manufacturing Tech ", SpecValue = "7nm", ProductId = 4 },
            new Specification { Id = 34, SpecLabel = "Memory Types", SpecValue = "DDR4 3200", ProductId = 4 },
            new Specification { Id = 35, SpecLabel = "Thermal Design Power ", SpecValue = "105W", ProductId = 4 },

            //Ryzen 7 5700X
            new Specification { Id = 36, SpecLabel = "Series", SpecValue = "Ryzen 7 5000 Series", ProductId = 5 },
            new Specification { Id = 79, SpecLabel = "CPU Socket Type ", SpecValue = "Socket AM4", ProductId = 5 },
            new Specification { Id = 37, SpecLabel = "# of Cores ", SpecValue = "8-Core", ProductId = 5 },
            new Specification { Id = 38, SpecLabel = "# of Threads ", SpecValue = "16", ProductId = 5 },
            new Specification { Id = 39, SpecLabel = "Operating Frequency  ", SpecValue = "3.3 GHz", ProductId = 5 },
            new Specification { Id = 40, SpecLabel = "Max Turbo Frequency ", SpecValue = "4.3 GHz", ProductId = 5 },
            new Specification { Id = 41, SpecLabel = "L2 Cache ", SpecValue = "4MB", ProductId = 5 },
            new Specification { Id = 42, SpecLabel = "L3 Cache ", SpecValue = "32MB", ProductId = 5 },
            new Specification { Id = 43, SpecLabel = "Manufacturing Tech ", SpecValue = "7nm", ProductId = 5 },
            new Specification { Id = 44, SpecLabel = "Memory Types", SpecValue = "DDR4 3200", ProductId = 5 },
            new Specification { Id = 45, SpecLabel = "Thermal Design Power ", SpecValue = "105W", ProductId = 5 },

            //Intel 12700K
            new Specification { Id = 46, SpecLabel = "Series", SpecValue = "Core i7 12th Gen", ProductId = 6 },
            new Specification { Id = 47, SpecLabel = "CPU Socket Type", SpecValue = "LGA 1700", ProductId = 6 },
            new Specification { Id = 48, SpecLabel = "Core Name", SpecValue = "Alder Lake", ProductId = 6 },
            new Specification { Id = 49, SpecLabel = "# of Cores ", SpecValue = "12-Core (8P+4E)", ProductId = 6 },
            new Specification { Id = 50, SpecLabel = "# of Threads ", SpecValue = "20", ProductId = 6 },
            new Specification { Id = 51, SpecLabel = "Operating Frequency  ", SpecValue = "3.6 GHz", ProductId = 6 },
            new Specification { Id = 52, SpecLabel = "Max Turbo Frequency ", SpecValue = "Up to 4.9 GHz", ProductId = 6 },
            new Specification { Id = 53, SpecLabel = "L2 Cache ", SpecValue = "12MB", ProductId = 6 },
            new Specification { Id = 54, SpecLabel = "L3 Cache ", SpecValue = "25MB", ProductId = 6 },
            new Specification { Id = 55, SpecLabel = "Manufacturing Tech ", SpecValue = "Intel 7", ProductId = 6 },
            new Specification { Id = 56, SpecLabel = "Memory Types", SpecValue = "DDR4 3200 / DDR5 4800", ProductId = 6 },
            new Specification { Id = 57, SpecLabel = "Thermal Design Power ", SpecValue = "190W", ProductId = 6 },


            //Intel 12900K
            new Specification { Id = 58, SpecLabel = "Series", SpecValue = "Core i7 11th Gen", ProductId = 7 },
            new Specification { Id = 59, SpecLabel = "CPU Socket Type", SpecValue = "LGA 1700", ProductId = 7 },
            new Specification { Id = 60, SpecLabel = "Core Name", SpecValue = "Alder Lake", ProductId = 7 },
            new Specification { Id = 61, SpecLabel = "# of Cores ", SpecValue = "12-Core", ProductId = 7 },
            new Specification { Id = 62, SpecLabel = "# of Threads ", SpecValue = "24", ProductId = 7 },
            new Specification { Id = 63, SpecLabel = "Operating Frequency  ", SpecValue = "3.6 GHz", ProductId = 7 },
            new Specification { Id = 64, SpecLabel = "Max Turbo Frequency ", SpecValue = "Up to 4.9 GHz", ProductId = 7 },
            new Specification { Id = 65, SpecLabel = "L2 Cache ", SpecValue = "12MB", ProductId = 7 },
            new Specification { Id = 66, SpecLabel = "L3 Cache ", SpecValue = "25MB", ProductId = 7 },
            new Specification { Id = 67, SpecLabel = "Manufacturing Tech ", SpecValue = "Intel 7", ProductId = 7 },
            new Specification { Id = 68, SpecLabel = "Memory Types", SpecValue = "DDR4 3200 ", ProductId = 7 },
            new Specification { Id = 69, SpecLabel = "Thermal Design Power ", SpecValue = "190W", ProductId = 7 },

            //Ram  CORSAIR
            new Specification { Id = 70, SpecLabel = "Capacity", SpecValue = "16GB (2 x 8GB)", ProductId = 8 },
            new Specification { Id = 71, SpecLabel = "Type", SpecValue = "288-Pin DDR4 SDRAM", ProductId = 8 },
            new Specification { Id = 72, SpecLabel = "Speed ", SpecValue = "DDR4 3200 (PC4 25600)", ProductId = 8 },
            new Specification { Id = 73, SpecLabel = "CAS Latency ", SpecValue = "16", ProductId = 8 },
            new Specification { Id = 74, SpecLabel = "Timing", SpecValue = "16-18-18-36", ProductId = 8 },
            new Specification { Id = 75, SpecLabel = "Voltage ", SpecValue = "1.35V", ProductId = 8 },
            new Specification { Id = 76, SpecLabel = "Chipset", SpecValue = "Intel XMP 2.0", ProductId = 8 },
            new Specification { Id = 77, SpecLabel = "Color", SpecValue = "Black", ProductId = 8 },
            new Specification { Id = 78, SpecLabel = "Heat Spreader", SpecValue = "Anodized Aluminum", ProductId = 8 }
        );
    }
}
