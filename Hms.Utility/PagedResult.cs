using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Utility
{
public class PagedResult<T> where T:class
    {
        public int pageNumber;
        public int pageSize;

        public PagedResult()
        {

        }
        public List<T> Data { get; set; }
        public int TotalItems { get; set; }
        public  int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
