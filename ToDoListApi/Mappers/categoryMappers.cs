using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Dtos.CategoryDto;
using ToDoListApi.Models;

namespace ToDoListApi.Mappers
{
    public static class categoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Name = category.Name
            };
        }
        
    }
}