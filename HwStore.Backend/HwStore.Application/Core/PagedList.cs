using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Core
{
    public class PagedList<T>
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; }
        public int TotalPage
        {
            get => (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
        public List<T> Items { get; set; }
    }
}
