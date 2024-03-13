using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApi.Dtos.ToDoDto
{
    public class CreateToDoDto
    {
       
        public string Description { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        public  int CategoryID { get; set; }

        public  int StatusID { get; set; }

        

        
    }
}