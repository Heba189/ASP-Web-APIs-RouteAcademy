using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications.ProductSpec
{
    public class ProductsWithFiltersForCountSpecification: Specification<Product>
    {
    public ProductsWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
    : base(p =>
     (string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search)) &&
     (!productSpecParams.typeId.HasValue || p.ProductTypeId == productSpecParams.typeId.Value) &&
     (!productSpecParams.brandId.HasValue || p.ProductBrandId == productSpecParams.brandId.Value))
        {

        }
    }
}
