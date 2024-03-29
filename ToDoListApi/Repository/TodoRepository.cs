using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ToDoListApi.Data;
using ToDoListApi.Dtos.ToDoDto;
using ToDoListApi.Interfaces;
using ToDoListApi.Models;

namespace ToDoListApi.Repository
{
    public class TodoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDo> CreateAsync(ToDo todo)
        {
            await _context.todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            
            return todo;
        }

        public async Task<ToDo?> DeleteAsync(int id)
        {
            var todo = await _context.todos.FirstOrDefaultAsync(td => td.Id == id);
            if(todo == null){
                return null;
            }
            _context.todos.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
           return await _context.todos.Include( c=> c.Category).Include(s=> s.Status).ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(int id)
        {
            return await _context.todos.Include(c => c.Category).FirstOrDefaultAsync(td => td.Id == id);
        }

        public async Task<IEnumerable<ToDo>> GetToDosForUserAsync(string userId)
        {
            return await _context.todos.Where(td=> td.AppUserId == userId).Include( c=> c.Category).Include(s=> s.Status).ToListAsync();
        }

        public async Task<ToDo?> UpdateAsync(int id, UpdateToDoDto toDoDto)
        {
            var todo = await _context.todos.FirstOrDefaultAsync(td => td.Id == id);

            if(todo == null){
                return null;
            }
            todo.description = toDoDto.Description;
            todo.DueDate = toDoDto.DueDate;
            todo.CategoryId = toDoDto.CategoryID;
            todo.StatusId = toDoDto.StatusID;

            await _context.SaveChangesAsync();
            return todo;


        }
    }
}