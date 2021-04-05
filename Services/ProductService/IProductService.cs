using System.Collections.Generic;
using System.Threading.Tasks;
using Test.DTOs.Product;
using Test.Models;

namespace Test.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetProducts();
        Task<ServiceResponse<GetProductDto>> GetProduct(int Id);
        Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedPro);

         
    }
}