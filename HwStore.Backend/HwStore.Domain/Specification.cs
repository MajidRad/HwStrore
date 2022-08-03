using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain
{
    public class Specification
    {
        public int Id { get; set; }
        public string? SpecLabel { get; set; }
        public string? SpecValue { get; set; }

        public Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}
