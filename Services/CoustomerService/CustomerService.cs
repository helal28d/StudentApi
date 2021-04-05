using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.DTOs.Customer;
using Test.Models;

namespace Test.Services.CoustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public CustomerService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
       
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> AddCustomer(AddCustomerDto newCustomer)
        {
            ServiceResponse<List<GetCustomerDto>> response = new ServiceResponse<List<GetCustomerDto>>();
            try
            {
                Customer customer = _mapper.Map<Customer>(newCustomer);
                await _dataContext.Customers.AddAsync(customer);
                await _dataContext.SaveChangesAsync();

                response.Data = _dataContext.Customers.Select(x => _mapper.Map<GetCustomerDto>(x)).ToList();
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

        public async Task<ServiceResponse<GetCustomerDto>> GetCustomer(int id)
        {
            ServiceResponse<GetCustomerDto> response = new ServiceResponse<GetCustomerDto>();
            try
            {
                Customer customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
                response.Data = _mapper.Map<GetCustomerDto>(customer);
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

        public async Task<ServiceResponse<List<GetCustomerDto>>> GetCustomers()
        {
            ServiceResponse<List<GetCustomerDto>> response = new ServiceResponse<List<GetCustomerDto>>();
            try
            {
                List<Customer> customers = await _dataContext.Customers.ToListAsync();
                response.Data = customers.Select(x => _mapper.Map<GetCustomerDto>(x)).ToList();
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