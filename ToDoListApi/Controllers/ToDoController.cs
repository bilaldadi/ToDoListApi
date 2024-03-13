using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Dtos.ToDoDto;
using ToDoListApi.Interfaces;
using ToDoListApi.Mappers;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [Route("api/ToDo")]
    [ApiController]
    public class ToDoController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IToDoRepository _todoRepo;
        private readonly UserManager<AppUser> _userManager;
        public ToDoController(ApplicationDbContext context , IToDoRepository toDoRepo , UserManager<AppUser> userManager)
        {
            _todoRepo = toDoRepo;
            _context = context;
            _userManager = userManager;
            
        }

        [HttpGet]
        [Authorize]
        
        public async Task<IActionResult> GetAll(){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            
            var todos = await _todoRepo.GetToDosForUserAsync(user.Id);
            var todoDto = todos.Select(td => td.ToToDoDto());
            return Ok(todoDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var todo = await _todoRepo.GetByIdAsync(id);
            if(todo == null){
                return NotFound();
            }
            return Ok(todo.ToToDoDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateToDoDto createToDoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!User.Identity.IsAuthenticated){
                return BadRequest("User not authenticated");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var userid = user.Id;
            var todo = createToDoDto.ToToDoFromCreateDto(userid);

            if (todo == null)
            {
                return BadRequest("Unable to create todo");
            }

            await _todoRepo.CreateAsync(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo.ToToDoDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateToDoDto updateToDoDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var todo = await _todoRepo.UpdateAsync(id,updateToDoDto);
            
            if(todo == null){
                return NotFound();
            }
            
            return Ok(todo.ToToDoDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async  Task<IActionResult> Delete([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var todo = await _todoRepo.DeleteAsync(id);
            if(todo == null){
                return NotFound();
             }
            return NoContent();
        }



        
    }
}