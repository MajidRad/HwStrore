using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository
{
    public class SpecificationRepository : GenericRepository<Specification>, ISpecificationRepository
    {
        private readonly HwStoreDbContext _db;
        private readonly IMapper _mapper;

        public SpecificationRepository(HwStoreDbContext db,IMapper mapper) : base(db,mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ICollection<Specification>> GetSpecById(int prodId)
        {
            var specs =await _db.Products.Include(x=>x.Specifications)
                .FirstOrDefaultAsync(x => x.Id == prodId);
            if (specs == null)
            {
                return null;
            }
            return specs.Specifications;
        }

        public Task Update(Specification specification)
        {
            throw new NotImplementedException();  
        }
    }
}
