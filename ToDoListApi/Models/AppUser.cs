using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ToDoListApi.Models
{
    public class AppUser: IdentityUser
    {
        public List<ToDo> ToDos { get; set; }
    }
}