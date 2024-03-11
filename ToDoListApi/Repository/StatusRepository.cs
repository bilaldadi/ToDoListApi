using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Interfaces;
using ToDoListApi.Models;

namespace ToDoListApi.Repository
{
    public class StatusRepository:IStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _context.statuses.ToListAsync();
        }
        
    }
}