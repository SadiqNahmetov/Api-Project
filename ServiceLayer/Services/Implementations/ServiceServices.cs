﻿using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Imlementations;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Header;
using ServiceLayer.DTOs.Service;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class ServiceServices : IServiceService
    {
        private readonly IServiceRepository _repo;
        private readonly IMapper _mapper;

        public ServiceServices(IServiceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }



        public async Task CreateAsync(ServiceCreateDto serviceCreateDto)
        {
            if (!await _repo.IsExsist(m => m.Name == serviceCreateDto.Name))
            {
                var mapData = _mapper.Map<Service>(serviceCreateDto);

                await _repo.CreateAsync(mapData);
            }
            else
            {
                throw new Exception("Service is alerdy exsist");
            }
        }


        public async Task<List<ServiceListDto>> GetAllAsync()
        {
            var model = await _repo.GetAllAsync();

            var result = _mapper.Map<List<ServiceListDto>>(model);

            return result;
        }

        public async Task<ServiceDto> GetAsync(int id)
        {
            var model = await _repo.GetAsync(id);

            var result = _mapper.Map<ServiceDto>(model);

            return result;
        }

        public async Task UpdateAsync(int id, ServiceUpdateDto serviceUpdateDto)
        {
            var dbHeader = await _repo.GetAsync(id);

            _mapper.Map(serviceUpdateDto, dbHeader);

            await _repo.UpdateAsync(dbHeader);
        }


        public async Task DeleteAsync(int id)
        {
            var slider = await _repo.GetAsync(id);

            await _repo.DeleteAsync(slider);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _repo.SoftDelete(await _repo.GetAsync(id));
        }
    }
}
