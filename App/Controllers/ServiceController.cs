﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Banner;
using ServiceLayer.DTOs.Service;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers
{
    public class ServiceController : AppController
    {
        private readonly IServiceService _serviceService;
        private readonly IWebHostEnvironment _env;

        public ServiceController(IServiceService serviceService, IWebHostEnvironment env)
        {
            _serviceService = serviceService;
            _env = env;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ServiceCreateDto serviceCreateDto)
        {
            try
            {
                await _serviceService.CreateAsync(serviceCreateDto);

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
                return Ok(await _serviceService.GetAsync(id));
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
                return Ok(await _serviceService.GetAllAsync());
            }
            catch (Exception)
            {
                return NotFound("No records found!");
            }
        }


        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([Required][FromRoute] int id, [FromForm] ServiceUpdateDto serviceUpdateDto)
        {
            try
            {
                await _serviceService.UpdateAsync(id, serviceUpdateDto);

                return Ok();
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
                await _serviceService.DeleteAsync(id);

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
                await _serviceService.SoftDeleteAsync(id);

                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

    }
}
