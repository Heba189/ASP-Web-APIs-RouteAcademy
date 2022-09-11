using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.API.Dtos;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.BLL.Interfaces;
using Talabat.BLL.ProductSpec;
using Talabat.BLL.Specifications;
using Talabat.BLL.Specifications.ProductSpec;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{
  
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _typesRepo;
        private readonly IGenericRepository<ProductBrand> _brandsRepo;
        private readonly IMapper _mapper;
       // _typesRepo
        public ProductsController(IGenericRepository<Product> productsRepo,IGenericRepository<ProductBrand> brandsRepo ,IGenericRepository<ProductType> typesRepo,  IMapper mapper)
        {
            _productsRepo = productsRepo;
            _typesRepo = typesRepo;
            _brandsRepo = brandsRepo;
            _mapper = mapper;
        }
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
       // [Authorize]
        [HttpGet]
        //public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
       // public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            // var Products = await _productsRepo.GetAllAsync();
           
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);
            var products = await _productsRepo.GetAllWithSpecAsync(spec);
            // return Ok(products);

            // return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
            var Data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var countSpec = new ProductsWithFiltersForCountSpecification(productSpecParams);
            var count =await _productsRepo.GetCountAsync(countSpec);
            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex,productSpecParams.PageSize, count, Data));
        } 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType( typeof(ApiResponse),StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {        
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpecAsync(spec);
            //return Ok(product);
            var productDto = _mapper.Map<Product, ProductToReturnDto>(product);
            if(productDto == null) return NotFound(new ApiResponse(404));
            return Ok(productDto);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _brandsRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await _typesRepo.GetAllAsync();
            return Ok(types);
        }
    }
}
