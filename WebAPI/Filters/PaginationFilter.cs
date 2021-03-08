using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Filters
{
    public class PaginationFilter
    {
        private const int _maxPageSize = 10;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = _maxPageSize;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1: pageNumber;
            PageSize = pageSize > _maxPageSize ? _maxPageSize : pageSize;
        }
    }
}
