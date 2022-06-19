using HwStore.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HwStoreDbContext _db;
        public UnitOfWork(HwStoreDbContext db)
        {
            _db = db;
            ProductRepository = new ProductRepostiory(_db);
        }
        public IProductRepository ProductRepository { get; private set; }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
