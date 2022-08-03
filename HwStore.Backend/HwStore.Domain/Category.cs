using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ParentCategoryId { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
