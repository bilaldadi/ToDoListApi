using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Models;

namespace ToDoListApi.Dtos.ToDoDto
{
    public class ToDoDto
    {
         public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        public int CategoryID { get; set; }

        public  Category ?Category { get; set; }

        public  int StatusID { get; set; }

        

        
    }
}