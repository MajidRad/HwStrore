﻿using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.Core;
using HwStore.Domain;
using Microsoft.EntityFrameworkCore;

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
    public async Task Update(Product product)
    {
        var productFromDb = await _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
    }


    public async Task<PagedList<Product>> GetProducts(PaginationParams param)
    {
        throw new NotImplementedException();
    }
}
