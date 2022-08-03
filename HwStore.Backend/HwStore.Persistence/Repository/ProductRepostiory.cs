using AutoMapper;
using AutoMapper.QueryableExtensions;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.Core;
using HwStore.Application.DTOs.Product;
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository;

public class ProductRepostiory : GenericRepository<Product>, IProductRepository
{
    private HwStoreDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepostiory(HwStoreDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<Product> GetProductWithDetails(int id)
    {

        return await _db.Products
            .Include(q => q.Category)
            .Include(q => q.Brand)
            .Include(q => q.Images)
            .Include(q => q.Specifications)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}

