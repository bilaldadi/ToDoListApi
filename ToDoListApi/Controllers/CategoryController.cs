using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Data;
using ToDoListApi.Interfaces;
using ToDoListApi.Mappers;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
      

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categories = await _categoryRepo.GetAllAsync();
            var categoryDto = categories.Select(s=>s.ToCategoryDto());
            return Ok(categoryDto); 
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }
    }
}