using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Domain;

namespace HwStore.Persistence.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly HwStoreDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(HwStoreDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Task Update(Category category)
    {
        throw new NotImplementedException();
    }
}
