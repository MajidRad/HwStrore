using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain.Order
{
    [Owned]
    public class ProductItemOrdered
    {
        public int productId { get; set; }
        public string? Name { get; set; }
        public string pictrureUrl { get; set; }
    }
}
