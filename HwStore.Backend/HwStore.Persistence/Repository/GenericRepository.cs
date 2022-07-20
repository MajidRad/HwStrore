using AutoMapper;
using AutoMapper.QueryableExtensions;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.Core;
using HwStore.Application.DTOs.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.Repository
{
    public class GenericRepository<T> : IGenricRepository<T> where T : class
    {
        private readonly IMapper _mapper;
        private readonly HwStoreDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(HwStoreDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
            dbSet = _db.Set<T>();

        }
        public async Task<T> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }



        public async Task<bool> Exist(Expression<Func<T, bool>> expression)
        {
            var res = await dbSet.Where(expression).FirstOrDefaultAsync();
            if (res == null) return false;
            return true;
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            #pragma warning disable CS8603 // Possible null reference return.
            return await query.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<T>> GetListAsync(string? includeProp)
        {
            IQueryable<T> query = dbSet;
            if (includeProp != null)
            {
                foreach (var item in includeProp
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dbSet.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<PagedList<TResult>> GetPagedListAsync<TResult>(PaginationParams param)
        {
            var query = dbSet
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .AsQueryable();

            var results = await PagedList<TResult>.ToPageList(query, param.PageNumber, param.PageSize);
            return results;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(T entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
