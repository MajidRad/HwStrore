using AutoMapper;
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
        private readonly IMapper _mapper;

        public UnitOfWork(HwStoreDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            ProductRepository = new ProductRepostiory(_db,_mapper);
            CategoryRepository = new CategoryRepository(_db,_mapper);
            BrandRepository = new BrandRepository(_db,_mapper);
            SpecificationRepository = new SpecificationRepository(_db,_mapper);
        }
        public IProductRepository ProductRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public ISpecificationRepository SpecificationRepository { get; private set; }

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
