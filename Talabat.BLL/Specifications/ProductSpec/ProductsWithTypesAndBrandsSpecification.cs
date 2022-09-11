using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.BLL.Specifications.ProductSpec;
using Talabat.DAL.Entities;

namespace Talabat.BLL.ProductSpec
{
  public class ProductsWithTypesAndBrandsSpecification:Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
            :base(p => 
            (string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))&&
            (!productSpecParams.typeId.HasValue || p.ProductTypeId == productSpecParams.typeId.Value) &&
            (!productSpecParams.brandId.HasValue || p.ProductBrandId == productSpecParams.brandId.Value))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            AddOrderBy(p => p.Name);
            ApplyPagination(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);
             if (!string.IsNullOrEmpty(productSpecParams.sort))
            {
                switch (productSpecParams.sort)
                {
                    case "priceAsc":
                    AddOrderBy(p=>p.Price);
                    break;
                    case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                    default:
                    AddOrderBy(p=>p.Name);
                    break;


                }
                    

            }
             

        }   
        public ProductsWithTypesAndBrandsSpecification(int id):base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}
