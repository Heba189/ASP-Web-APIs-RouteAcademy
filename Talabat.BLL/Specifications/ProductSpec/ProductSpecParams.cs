using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.BLL.Specifications.ProductSpec
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int pageSize =5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? 50:value; }
        }

        public  string sort { get; set; }
        public int? typeId{ get; set; }
        public int? brandId { get; set; }

        private string search;

        public string Search
        {
            get { return search; }
            set { search = value.ToLower(); }
        }


    }
}
