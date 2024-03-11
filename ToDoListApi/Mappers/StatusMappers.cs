using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Dtos.StatusDto;
using ToDoListApi.Models;

namespace ToDoListApi.Mappers
{
    public static class StatusMappers
    {
        public static StatusDto ToStatusDto(this Status status)
        {
            return new StatusDto
            {
                Name = status.Name
            };
        }
    }
}