using HwStore.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.DTOs.Order;
public class OrderDto_Create
{
    public bool SaveAddress { get; set; }
    public ShippingAddress? ShippingAddress { get; set; }

}
