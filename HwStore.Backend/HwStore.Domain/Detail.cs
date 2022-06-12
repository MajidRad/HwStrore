using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain
{
    public class Detail
    {
        public int Id { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyValue { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
