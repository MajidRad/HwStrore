using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Persistence
{
    public interface IGenricRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetListAsync(string? includeProp = null);

        Task<PagedList<TResult>> GetPagedListAsync<TResult>(PaginationParams param);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter,
         params Expression<Func<T, object>>[] includes);
        Task<T> Add(T entity);

        void Remove(T entity);
        void RemoveRange(T entities);

    }
}
