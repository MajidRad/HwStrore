using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string? BuyerId { get; set; }
        public ShippingAddress? shippingAddress { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem>? OrderItems { get; set; }

        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public decimal Total()
        {
          return  Subtotal + DeliveryFee;
        }
    }
}
