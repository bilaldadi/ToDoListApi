using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ToDoListApi.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]public string description { get; set; } = string.Empty;

        [Required]public DateTime? DueDate { get; set; }

        [Required]public int CategoryId { get; set; }

        public  Category ? Category { get; set; }

        [Required]public int StatusId { get; set; }

        public Status? Status { get; set; }

        public bool Overdue => StatusId == 1 && DueDate < DateTime.Now;

        public string AppUserId { get; set; }

        public AppUser User { get; set; }

    }
}