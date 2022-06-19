using HwStore.Application.Contract.Persistence;
using HwStore.Domain;
using HwStore.Persistence.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository
{
    public class ProductRepostiory : GenericRepository<Product>, IProductRepository
    {
        private HwStoreDbContext _db;
        public ProductRepostiory(HwStoreDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Product> GetProductWithDetails(int id)
        {
          

            return await _db.Products
                .Include(q => q.Category)
                .Include(q=>q.Brand)
                .Include(q=>q.Images)
                .FirstOrDefaultAsync(x=>x.Id==id);
           
            
        }
        public async Task Update(Product product)
        {
            var productFromDb = await _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        }
    }
}
