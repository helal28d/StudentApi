using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.DTOs.Product;
using Test.Models;

namespace Test.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public ProductService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto newProduct)
        {
            ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();
            try
            {
                Product product=_mapper.Map<Product>(newProduct);
                await _dataContext.Products.AddAsync(product);
                await _dataContext.SaveChangesAsync();
                response.Data=_mapper.Map<GetProductDto>(product);
                response.Success = true;
                response.Message = "success";
            }
            catch (Exception ex)
            {
                  response.Message = "error" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProduct(int Id)
        {
             ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();
            try
            {
                Product product=await _dataContext.Products.FirstOrDefaultAsync(x=>x.Id==Id);
                
                response.Data=_mapper.Map<GetProductDto>(product);
                response.Success = true;
                response.Message = "success";
            }
            catch (Exception ex)
            {
                  response.Message = "error" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetProducts()
        {
           ServiceResponse<List<GetProductDto>> response=new ServiceResponse<List<GetProductDto>>();
            try
            {
                List<Product> products=await _dataContext.Products
                .Include(p=>p.customer)
                .Include(p=>p.Gategory)
                .ToListAsync();
                
                response.Data=products.Select(p=>_mapper.Map<GetProductDto>(p)).ToList();
                response.Success = true;
                response.Message = "success";
            }
            catch (Exception ex)
            {
                  response.Message = "error" + ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedPro)
        {
             ServiceResponse<GetProductDto> response = new ServiceResponse<GetProductDto>();
            try
            {
                Product product=await _dataContext.Products.FirstOrDefaultAsync(x=>x.Id==updatedPro.Id);
                product.Price=updatedPro.Price;
                product.Qantity=updatedPro.Qantity;
                 _dataContext.Products.Update(product);
                 await _dataContext.SaveChangesAsync();
                response.Data=_mapper.Map<GetProductDto>(product);
                response.Success = true;
                response.Message = "success";
            }
            catch (Exception ex)
            {
                  response.Message = "error" + ex.Message;
                response.Success = false;
            }
            return response;
            
        }
    }
}