using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.API.Specifications
{
    public interface ISpecification<T> 
    {
        public Expression<Func<T,bool>> Criteria { get; set; }
        public List<Expression<Func<T,Object>>> Includes { get; set; }
        public Expression<Func<T,object>> OrderBy { get; set; }
        public Expression<Func<T,object>> OrderByDescending { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }

        public bool IsPaginationEnabled { get; set; }
    }
}
