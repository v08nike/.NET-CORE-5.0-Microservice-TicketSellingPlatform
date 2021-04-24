using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSale.Services.Catalog.Dtos;
using TicketSale.Services.Catalog.Models;
using TicketSale.Services.Catalog.Services;
using TicketSale.Shared.ControllerBases;

namespace TicketSale.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreatActionResultInstance(categories);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            return CreatActionResultInstance(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category categoryDto)
        {
            var response = await _categoryService.CreateAsync(categoryDto);
            return CreatActionResultInstance(response);
        }
    }
}
