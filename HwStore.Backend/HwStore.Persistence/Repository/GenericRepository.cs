using HwStore.Application.Contract.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Persistence.GenericRepository
{
    public class GenericRepository<T> : GenricRepository<T> where T : class
    {
        private readonly HwStoreDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(HwStoreDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
           await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp)
        {
            IQueryable<T> query = dbSet;
            query =  query.Where(filter);
            if (includeProp != null)
            {
                foreach(var item in includeProp
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(item);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(string? includeProp)
        {
            IQueryable<T> query = dbSet;
            if(includeProp != null)
            {
                foreach (var item in includeProp
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dbSet.Include(item);
                }
            }
                return await query.ToListAsync();
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
