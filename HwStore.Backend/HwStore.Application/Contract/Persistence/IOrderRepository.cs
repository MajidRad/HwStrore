using HwStore.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Persistence;
public interface IOrderRepository:IGenricRepository<Order>
{
    Task<List<Order>> GetOreders(string buyerId);
}
