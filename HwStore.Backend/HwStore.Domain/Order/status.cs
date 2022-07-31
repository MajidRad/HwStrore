using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain.Order
{
    public enum OrderStatus
    {
        Pending,
        PaymentRecived,
        PaymentFailed
    }
}
