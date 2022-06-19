using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Configuration.Entities
{
    internal class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.HasData(
                //Rx 6800xt
                new Specification { Id = 1, SpecLabel = "INTERFACE", SpecValue = "PCI Express® Gen 4", productId = 1 },
                new Specification { Id = 2, SpecLabel = "CORES", SpecValue = "4608 Units", productId = 1 },
                new Specification { Id = 3, SpecLabel = "CORE CLOCKS", SpecValue = "Boost: Up to 2310 MHz / Game: Up to 2065 MHz", productId = 1 },
                new Specification { Id = 4, SpecLabel = "MEMORY SPEED", SpecValue = "16 Gbps", productId = 1 },
                new Specification { Id = 5, SpecLabel = "MEMORY ", SpecValue = "16GB GDDR6", productId = 1 },
                new Specification { Id = 6, SpecLabel = "MEMORY BUS", SpecValue = "256-bit", productId = 1 },
                new Specification { Id = 7, SpecLabel = "OUTPUT", SpecValue = "DisplayPort x 3 (v1.4)", productId = 1 },
                new Specification { Id = 8, SpecLabel = "POWER CONNECTORS", SpecValue = "300 W", productId = 1 },


                //Rx 6700xt
                new Specification { Id = 9, SpecLabel = "INTERFACE", SpecValue = "PCI Express® Gen 4", productId = 2 },
                new Specification { Id = 10, SpecLabel = "CORES", SpecValue = "2560 Units", productId = 2 },
                new Specification { Id = 11, SpecLabel = "CORE CLOCKS", SpecValue = "Boost: Up to 2620 MHz / Game: Up to 2474 MHz", productId = 2 },
                new Specification { Id = 12, SpecLabel = "MEMORY SPEED", SpecValue = "16 Gbps", productId =2 },
                new Specification { Id = 13, SpecLabel = "MEMORY ", SpecValue = "12GB GDDR6", productId = 2 },
                new Specification { Id = 14, SpecLabel = "MEMORY BUS", SpecValue = "192-bit", productId = 2 },
                new Specification { Id = 15, SpecLabel = "OUTPUT", SpecValue = "DisplayPort x 3 (v1.4)", productId = 2 },
                new Specification { Id = 16, SpecLabel = "POWER CONNECTORS", SpecValue = "230 W", productId = 3 },


                 //RTX 3070
                 new Specification { Id = 17, SpecLabel = "INTERFACE", SpecValue = "PCI Express® Gen 4", productId = 3 },
                new Specification { Id = 18, SpecLabel = "CORES", SpecValue = "5888 Units", productId = 3 },
                new Specification { Id = 19, SpecLabel = "CORE CLOCKS", SpecValue = "Boost:Boost: 1845 MHz", productId = 3 },
                new Specification { Id = 20, SpecLabel = "MEMORY SPEED", SpecValue = "14 Gbps", productId = 3 },
                new Specification { Id = 21, SpecLabel = "MEMORY ", SpecValue = "8GB GDDR6", productId = 3 },
                new Specification { Id = 22, SpecLabel = "MEMORY BUS", SpecValue = "256-bit", productId = 3 },
                new Specification { Id = 23, SpecLabel = "OUTPUT", SpecValue = "DisplayPort x 3 (v1.4) / HDMI x 1 (Supports 4K@120Hz as specified in HDMI 2.1)", productId = 3 },
                new Specification { Id = 24, SpecLabel = "POWER CONNECTORS", SpecValue = "240W", productId = 3 },

                 //Ryzen 7 5800X

                new Specification { Id = 25, SpecLabel = "Series", SpecValue = "Ryzen 7 5000 Series", productId = 4 },
                 new Specification { Id = 26, SpecLabel = "CPU Socket Type ", SpecValue = "Socket AM4", productId = 4 },
                new Specification { Id = 27, SpecLabel = "# of Cores ", SpecValue = "8-Core", productId = 4 },
                new Specification { Id = 28, SpecLabel = "# of Threads ", SpecValue = "16", productId = 4 },
                new Specification { Id = 29, SpecLabel = "Operating Frequency  ", SpecValue = "3.8 GHz", productId = 4 },
                new Specification { Id = 30, SpecLabel = "Max Turbo Frequency ", SpecValue = "4.7 GHz", productId = 4 },
                new Specification { Id = 31, SpecLabel = "L2 Cache ", SpecValue = "4MB", productId = 4 },
                new Specification { Id = 32, SpecLabel = "L3 Cache ", SpecValue = "32MB", productId = 4 },
                new Specification { Id = 33, SpecLabel = "Manufacturing Tech ", SpecValue = "7nm", productId = 4 },
                new Specification { Id = 34, SpecLabel = "Memory Types", SpecValue = "DDR4 3200", productId = 4 },
                new Specification { Id = 35, SpecLabel = "Thermal Design Power ", SpecValue = "105W", productId = 4 },

                //Ryzen 7 5700X
                new Specification { Id = 36, SpecLabel = "Series", SpecValue = "Ryzen 7 5000 Series", productId = 5 },
                new Specification { Id = 79, SpecLabel = "CPU Socket Type ", SpecValue = "Socket AM4", productId = 5 },
                new Specification { Id = 37, SpecLabel = "# of Cores ", SpecValue = "8-Core", productId = 5 },
                new Specification { Id = 38, SpecLabel = "# of Threads ", SpecValue = "16", productId = 5 },
                new Specification { Id = 39, SpecLabel = "Operating Frequency  ", SpecValue = "3.3 GHz", productId = 5 },
                new Specification { Id = 40, SpecLabel = "Max Turbo Frequency ", SpecValue = "4.3 GHz", productId = 5 },
                new Specification { Id = 41, SpecLabel = "L2 Cache ", SpecValue = "4MB", productId = 5 },
                new Specification { Id = 42, SpecLabel = "L3 Cache ", SpecValue = "32MB", productId = 5 },
                new Specification { Id = 43, SpecLabel = "Manufacturing Tech ", SpecValue = "7nm", productId = 5 },
                new Specification { Id = 44, SpecLabel = "Memory Types", SpecValue = "DDR4 3200", productId = 5 },
                new Specification { Id = 45, SpecLabel = "Thermal Design Power ", SpecValue = "105W", productId = 5 },

                //Intel 12700K
                new Specification { Id = 46, SpecLabel = "Series", SpecValue = "Core i7 12th Gen", productId = 6 },
                new Specification { Id = 47, SpecLabel = "CPU Socket Type", SpecValue = "LGA 1700", productId = 6 },
                new Specification { Id = 48, SpecLabel = "Core Name", SpecValue = "Alder Lake", productId = 6 },
                new Specification { Id = 49, SpecLabel = "# of Cores ", SpecValue = "12-Core (8P+4E)", productId = 6 },
                new Specification { Id = 50, SpecLabel = "# of Threads ", SpecValue = "20", productId = 6 },
                new Specification { Id = 51, SpecLabel = "Operating Frequency  ", SpecValue = "3.6 GHz", productId = 6 },
                new Specification { Id = 52, SpecLabel = "Max Turbo Frequency ", SpecValue = "Up to 4.9 GHz", productId = 6 },
                new Specification { Id = 53, SpecLabel = "L2 Cache ", SpecValue = "12MB", productId = 6 },
                new Specification { Id = 54, SpecLabel = "L3 Cache ", SpecValue = "25MB", productId = 6 },
                new Specification { Id = 55, SpecLabel = "Manufacturing Tech ", SpecValue = "Intel 7", productId = 6 },
                new Specification { Id = 56, SpecLabel = "Memory Types", SpecValue = "DDR4 3200 / DDR5 4800", productId = 6 },
                new Specification { Id = 57, SpecLabel = "Thermal Design Power ", SpecValue = "190W", productId = 6 },
                
                
                //Intel 12900K
                new Specification { Id = 58, SpecLabel = "Series", SpecValue = "Core i7 11th Gen", productId = 7 },
                new Specification { Id = 59, SpecLabel = "CPU Socket Type", SpecValue = "LGA 1700", productId = 7 },
                new Specification { Id = 60, SpecLabel = "Core Name", SpecValue = "Alder Lake", productId = 7 },
                new Specification { Id = 61, SpecLabel = "# of Cores ", SpecValue = "12-Core", productId = 7 },
                new Specification { Id = 62, SpecLabel = "# of Threads ", SpecValue = "24", productId = 7 },
                new Specification { Id = 63, SpecLabel = "Operating Frequency  ", SpecValue = "3.6 GHz", productId = 7 },
                new Specification { Id = 64, SpecLabel = "Max Turbo Frequency ", SpecValue = "Up to 4.9 GHz", productId = 7 },
                new Specification { Id = 65, SpecLabel = "L2 Cache ", SpecValue = "12MB", productId = 7 },
                new Specification { Id = 66, SpecLabel = "L3 Cache ", SpecValue = "25MB", productId = 7 },
                new Specification { Id = 67, SpecLabel = "Manufacturing Tech ", SpecValue = "Intel 7", productId = 7 },
                new Specification { Id = 68, SpecLabel = "Memory Types", SpecValue = "DDR4 3200 ", productId = 7 },
                new Specification { Id = 69, SpecLabel = "Thermal Design Power ", SpecValue = "190W", productId = 7 },

                //Ram  CORSAIR
                new Specification { Id = 70, SpecLabel = "Capacity", SpecValue = "16GB (2 x 8GB)", productId = 8 },
                new Specification { Id = 71, SpecLabel = "Type", SpecValue = "288-Pin DDR4 SDRAM", productId = 8 },
                new Specification { Id = 72, SpecLabel = "Speed ", SpecValue = "DDR4 3200 (PC4 25600)", productId = 8 },
                new Specification { Id = 73, SpecLabel = "CAS Latency ", SpecValue = "16", productId = 8 },
                new Specification { Id = 74, SpecLabel = "Timing", SpecValue = "16-18-18-36", productId = 8 },
                new Specification { Id = 75, SpecLabel = "Voltage ", SpecValue = "1.35V", productId = 8 },
                new Specification { Id = 76, SpecLabel = "Chipset", SpecValue = "Intel XMP 2.0", productId = 8 },
                new Specification { Id = 77, SpecLabel = "Color", SpecValue = "Black", productId = 8 },
                new Specification { Id = 78, SpecLabel = "Heat Spreader", SpecValue = "Anodized Aluminum", productId = 8 }
            );
        }
    }
}
