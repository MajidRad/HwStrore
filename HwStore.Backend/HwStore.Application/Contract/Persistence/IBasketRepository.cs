using HwStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Persistence
{
    public interface IBasketRepository:IGenricRepository<Basket>
    {
        Task<Basket> GetBasket(string buyierId);

     
        Task RemoveItem();

        Task RemoveBasket();

    }
}
