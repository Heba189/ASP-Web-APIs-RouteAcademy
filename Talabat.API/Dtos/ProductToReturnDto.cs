﻿namespace Talabat.API.Dtos
{
    //Dto:Data Transfer object
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        //public ProductType ProductType { get; set; } 
        public string ProductType { get; set; }
        public int ProductTypeId { get; set; }
       // public ProductBrand ProductBrand { get; set; }
        public string ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

    }
}
