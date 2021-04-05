using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.DTOs.Gategory;
using Test.Models;

namespace Test.Services.GategoryService
{
    public class GategoryService : IGategoryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public GategoryService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetGategoryDto>>> AddGategory(AddGategoryDto newGategory)
        {
            ServiceResponse<List<GetGategoryDto>> response = new ServiceResponse<List<GetGategoryDto>>();
            try
            {
                Gategory gategory = _mapper.Map<Gategory>(newGategory);
                await _dataContext.Gategories.AddAsync(gategory);
                await _dataContext.SaveChangesAsync();

                response.Data = _dataContext.Gategories.Select(x => _mapper.Map<GetGategoryDto>(x)).ToList();
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

        public async Task<ServiceResponse<List<GetGategoryDto>>> GetGategories()
        {
            ServiceResponse<List<GetGategoryDto>> response = new ServiceResponse<List<GetGategoryDto>>();
            try
            {
                List<Gategory> gategories = await _dataContext.Gategories.ToListAsync();
                response.Data = gategories.Select(x => _mapper.Map<GetGategoryDto>(x)).ToList();
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

        public async Task<ServiceResponse<GetGategoryDto>> Gtegategory(int id)
        {
            ServiceResponse<GetGategoryDto> response = new ServiceResponse<GetGategoryDto>();
            try
            {
                Gategory gategory = await _dataContext.Gategories.FirstOrDefaultAsync(x => x.Id == id);
                response.Data = _mapper.Map<GetGategoryDto>(gategory);
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