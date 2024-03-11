using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Data;
using ToDoListApi.Dtos.ToDoDto;
using ToDoListApi.Models;

namespace ToDoListApi.Mappers
{
    public static class ToDoMappers
    {
        public static ToDoDto ToToDoDto(this ToDo toDoModel)
        {
            return new ToDoDto
            {
                Id = toDoModel.Id,
                Description = toDoModel.description,
                DueDate = toDoModel.DueDate,
                CategoryID = toDoModel.CategoryId,
                Category = toDoModel.Category,
                StatusID = toDoModel.StatusId,
                Status = toDoModel.Status
                
            };
        }

        public static ToDo ToToDoFromCreateDto(this CreateToDoDto createToDoDto)
        {
            return new ToDo
            {
                description = createToDoDto.Description,
                DueDate = createToDoDto.DueDate,
                CategoryId = createToDoDto.CategoryID,
                StatusId = createToDoDto.StatusID
            };
        }
        
            
        
    }
}