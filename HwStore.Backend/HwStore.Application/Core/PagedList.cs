using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwStore.Application.Contract.Persistence;


namespace HwStore.Application.Core
{
    public class PagedList<T>
    {
  
        public int CurrentPage { get; set; }
        public int TotalPages {
            get =>(int) Math.Ceiling(TotalCount / (double)PageSize);
        }

        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get;set; }
      

    }
}
