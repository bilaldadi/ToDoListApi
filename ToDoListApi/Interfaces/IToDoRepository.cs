using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Dtos.ToDoDto;
using ToDoListApi.Models;

namespace ToDoListApi.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetAllAsync();

        Task<ToDo?> GetByIdAsync(int id);

        Task<ToDo> CreateAsync(ToDo todo);

        Task<ToDo?> UpdateAsync(int id ,UpdateToDoDto toDoDto);

        Task<ToDo?> DeleteAsync(int id);


    }
}