﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Persistence
{
    public interface GenricRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetListAsync(string? includeProp);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter,string? includeProp);
        Task<T> Add(T entity);
 
        void Remove(T entity);
        void RemoveRange(T entities); 

    }
}
