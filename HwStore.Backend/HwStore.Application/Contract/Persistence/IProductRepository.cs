using HwStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Persistence
{
    public interface IProductRepository:IGenricRepository<Product>
    {
        Task<Product> GetProductWithDetails(int id);
    }
}
