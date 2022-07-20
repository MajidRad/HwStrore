﻿using AutoMapper;
using HwStore.Application.Contract.Persistence;
using HwStore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        private readonly HwStoreDbContext _db;
        private readonly IMapper _mapper;
        public BasketRepository(HwStoreDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Basket> GetBasket(string? buyerId)
        {
            var basket = await _db.Baskets
                .Include(p => p.BasketItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(x => x.Images)
                .FirstOrDefaultAsync(x => x.BuyerId == buyerId);
            return basket;
        }

        public Task RemoveBasket()
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem()
        {
            throw new NotImplementedException();
        }
    }
}
