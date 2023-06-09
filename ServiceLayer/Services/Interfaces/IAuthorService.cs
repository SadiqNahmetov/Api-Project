﻿using ServiceLayer.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetAsync(int id);
        Task<List<AuthorListDto>> GetAllAsync();
        Task CreateAsync(AuthorCreateDto authorCreateDto);

        Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto);
        Task<List<AuthorListDto>> SearchAsync(string? searchText);
        Task DeleteAsync(int id);

        Task SoftDeleteAsync(int id);


    }
}
