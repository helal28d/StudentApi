using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.DTOs.Gategory;
using Test.Services.GategoryService;

namespace Test.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GategoryController : ControllerBase
    {

        //get
        //post
        //delete
        //put
        private readonly IGategoryService _gategoryService;
        public GategoryController(IGategoryService gategoryService)
        {
            _gategoryService = gategoryService;
        }

        [HttpGet]
        [Route("GetAllGat")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gategoryService.GetGategories());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGategory(int id)
        {
            return Ok(await _gategoryService.Gtegategory(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddGategory(AddGategoryDto newGat)
        {
            return Ok(await _gategoryService.AddGategory(newGat));

        }
    }
}