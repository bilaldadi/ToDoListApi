using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Dtos.ToDoDto;
using ToDoListApi.Interfaces;
using ToDoListApi.Mappers;

namespace ToDoListApi.Controllers
{
    [Route("api/ToDo")]
    [ApiController]
    public class ToDoController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IToDoRepository _todoRepo;
        public ToDoController(ApplicationDbContext context , IToDoRepository toDoRepo)
        {
            _todoRepo = toDoRepo;
            _context = context;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var todos = await _todoRepo.GetAllAsync();
            var todoDto = todos.Select(td => td.ToToDoDto());
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var todo = await _todoRepo.GetByIdAsync(id);
            if(todo == null){
                return NotFound();
            }
            return Ok(todo.ToToDoDto());
        }

        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] CreateToDoDto createToDoDto){
            var todo =  createToDoDto.ToToDoFromCreateDto();
            await _todoRepo.CreateAsync(todo);
            return CreatedAtAction(nameof(GetById), new {id = todo.Id}, todo.ToToDoDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateToDoDto updateToDoDto){
            var todo = await _todoRepo.UpdateAsync(id,updateToDoDto);
            
            if(todo == null){
                return NotFound();
            }
            
            return Ok(todo.ToToDoDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async  Task<IActionResult> Delete([FromRoute] int id){
            var todo = await _todoRepo.DeleteAsync(id);
            if(todo == null){
                return NotFound();
             }
            return NoContent();
        }



        
    }
}