using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Domain.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository;
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly HwStoreDbContext _db;

    public OrderRepository(HwStoreDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
    }

    public async Task<List<Order>> GetOreders(string buyerId)
    {
        var orders = await _db.Orders
                     .Include(x => x.OrderItems)
                     .Where(x => x.BuyerId == buyerId)
                     .ToListAsync();
        return orders;
    }
}
