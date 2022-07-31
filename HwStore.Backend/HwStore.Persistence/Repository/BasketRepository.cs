using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.DTOs.Basket;
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace HwStore.Persistence.Repository;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    private readonly HwStoreDbContext _db;
    private readonly IMapper _mapper;
    public BasketRepository(HwStoreDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<Basket> GetBasket(string? buyerId)
    {

        var basket = await _db.Baskets
            .Include(p => p.BasketItems)
            .ThenInclude(p => p.Product)
            .ThenInclude(x => x.Images)
            .FirstOrDefaultAsync(x => x.BuyerId == buyerId);
        return basket;
    }

    public async Task UpdateBasket(BasketDto_Base basket)
    {
        var basketFromDb = _db.Baskets.FirstOrDefault(x => x.Id == basket.Id);
        basketFromDb.BuyerId = basket.BuyerId;
        _db.Baskets.Update(basketFromDb);
        await _db.SaveChangesAsync();
    }
}
