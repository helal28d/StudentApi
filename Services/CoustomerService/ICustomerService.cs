using System.Collections.Generic;
using System.Threading.Tasks;
using Test.DTOs.Customer;
using Test.Models;

namespace Test.Services.CoustomerService
{
    public interface ICustomerService
    {
         Task<ServiceResponse<List<GetCustomerDto>>> GetCustomers();
        Task<ServiceResponse<GetCustomerDto>> GetCustomer(int id);
        Task<ServiceResponse<List<GetCustomerDto>>> AddCustomer(AddCustomerDto newCustomer);
         
    }
}