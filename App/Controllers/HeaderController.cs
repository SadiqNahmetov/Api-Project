﻿using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.About;
using ServiceLayer.DTOs.Header;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers
{
    public class HeaderController : AppController
    {
        private readonly IHeaderService _headerService;
        private readonly IWebHostEnvironment _env;

        public HeaderController(IHeaderService headerService, IWebHostEnvironment env)
        {
            _headerService = headerService;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]HeaderCreateDto headerCreateDto)
        {
            try
            {
                await _headerService.CreateAsync(headerCreateDto);

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest(new { ErrorMessage = "Not Created" });
            }
        }
    
        [HttpGet]
        public async Task<IActionResult> GetById([Required] int id)
        {
            try
            {
                return Ok(await _headerService.GetAsync(id));
            }
            catch (Exception)
            {
                return NotFound("Please enter a valid Id!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _headerService.GetAllAsync());
            }
            catch (Exception)
            {
                return NotFound("No records found!");
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, [FromForm] HeaderUpdateDto headerUpdateDto)
        {
            try
            {
                await _headerService.UpdateAsync(id, headerUpdateDto);

                return Ok(headerUpdateDto);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Not Updated" });
            }
        }



        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _headerService.DeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete([Required] int id)
        {
            try
            {
                await _headerService.SoftDeleteAsync(id);

                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }


    }
}
