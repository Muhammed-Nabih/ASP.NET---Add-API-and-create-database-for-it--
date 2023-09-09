﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sallaty.API.Data;
using Sallaty.API.Models.Domain;
using Sallaty.API.Models.DTO;
using Sallaty.API.Repositories.Interface;

namespace Sallaty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository catedoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.catedoryRepository = categoryRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory (CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await catedoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}