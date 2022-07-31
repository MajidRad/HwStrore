using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain.Order
{
    public class OrderItem
    {
        public int Id { get; set; }
        public ProductItemOrdered? ItemOrdered {get;set;}
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
    }
}
