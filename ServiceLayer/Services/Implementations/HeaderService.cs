﻿using AutoMapper;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Header;
using ServiceLayer.DTOs.Slider;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class HeaderService : IHeaderService
    {
        private readonly IHeaderRepository _repo;
        private readonly IMapper _mapper;

     

        public HeaderService(IHeaderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public Task CreateAsync(HeaderCreateDto headerCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HeaderListDto>> GetAllAsync()
        {
            var model = await _repo.GetAllAsync();

            var result = _mapper.Map<List<HeaderListDto>>(model);

            return result;
        }

        public async Task<HeaderDto> GetAsync(int id)
        {
            var model = await _repo.GetAsync(id);

            var result = _mapper.Map<HeaderDto>(model);

            return result;
        }

        public Task UpdateAsync(int id, HeaderUpdateDto headerUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}