using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.DTOs.Customer;
using Test.Services.CoustomerService;


namespace Test.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;

        }
        [HttpGet("GetAll")]
        
        public async Task<IActionResult> GetAllCus()
        {
            return Ok(await _CustomerService.GetCustomers());

        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(await _CustomerService.GetCustomer(id));

        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDto pro)
        {
            return Ok(await _CustomerService.AddCustomer(pro));

        }

    }
}