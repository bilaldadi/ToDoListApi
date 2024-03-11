using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Models;

namespace ToDoListApi.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
    }
}