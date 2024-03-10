using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Interfaces;
using ToDoListApi.Models;

namespace ToDoListApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
             return await _context.categories.ToListAsync(); 
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.categories.FindAsync(id);
        }
    }
}