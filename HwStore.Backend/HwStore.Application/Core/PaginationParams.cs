using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Core
{
    public class PaginationParams
    {
        private static int MaxPageSize = 50;
        private int _pageSize = 10;
        public int PageNumber { get; set; }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
