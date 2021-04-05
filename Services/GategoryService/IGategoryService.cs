using System.Collections.Generic;
using System.Threading.Tasks;
using Test.DTOs.Gategory;
using Test.Models;

namespace Test.Services.GategoryService
{
    public interface IGategoryService
    {
        Task<ServiceResponse<List<GetGategoryDto>>> GetGategories();
        Task<ServiceResponse<GetGategoryDto>> Gtegategory(int id);
        Task<ServiceResponse<List<GetGategoryDto>>> AddGategory(AddGategoryDto newGategory);
         
    }
}