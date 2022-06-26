using AutoMapper;
using AutoMapper.QueryableExtensions;
using HwStore.Application.Contract.Persistence;
using HwStore.Application.Core;
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
        public GenericRepository(HwStoreDbContext db,IMapper mapper)
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

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.FirstAsync();
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
            int totalSize = await dbSet.CountAsync();
            var items = await dbSet
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedList<TResult>
            {
                Items = items,
                CurrentPage = param.PageNumber,
                PageSize = param.PageSize,
                TotalCount = totalSize,
            };
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
