using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.DTOs.Product;
using Test.Services.ProductService;

namespace Test.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        //get
        //post
        //delete
        //put
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getProducts(){
            return Ok(await _productService.GetProducts());

        }

        [HttpGet("{Id}")]
        // [Route("GetProById")]
         public async Task<IActionResult> GetProduct(int id){
             return Ok(await _productService.GetProduct(id));

         }
         [HttpPost]
         public async Task<IActionResult> AddProduct(AddProductDto pro){
             return Ok(await _productService.AddProduct(pro));

         }
         [HttpPut]
          public async Task<IActionResult> UpdateProduct(UpdateProductDto pro){
             return Ok(await _productService.UpdateProduct(pro));

         }

    }
}