using AutoMapper;
using Test.DTOs.Customer;
using Test.DTOs.Gategory;
using Test.DTOs.Product;
using Test.Models;

namespace Test
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Gategory,GetGategoryDto>();
            CreateMap<AddGategoryDto,Gategory>();

            CreateMap<Product,GetProductDto>();
            CreateMap<AddProductDto,Product>();
             

            CreateMap<Customer,GetCustomerDto>();
            CreateMap<AddCustomerDto,Customer>();
        }

        
    }
}