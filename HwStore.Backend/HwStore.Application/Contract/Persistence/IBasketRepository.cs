using HwStore.Application.DTOs.Basket;

namespace HwStore.Application.Contract.Persistence;

public interface IBasketRepository : IGenricRepository<Basket>
{
    Task<Basket> GetBasket(string buyierId);
    Task UpdateBasket(BasketDto_Base basket);
}
