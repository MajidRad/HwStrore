using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Domain;

namespace HwStore.Persistence.Repository;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    private readonly HwStoreDbContext _db;
    private readonly IMapper _mapper;

    public BrandRepository(HwStoreDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Task Update(Brand brand)
    {
        throw new NotImplementedException();
    }
}
