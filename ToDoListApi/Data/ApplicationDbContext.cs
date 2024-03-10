using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Category> categories {get ; set;}

        public DbSet<Status> statuses {get ; set;}

        public DbSet<ToDo> todos {get ; set;}


        // seed data 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Work"},
                new Category {Id = 2, Name = "Home"},
                new Category {Id = 3, Name = "Hobby"}
            );

            modelBuilder.Entity<Status>().HasData(
                new Status {Id = 1, Name = "Open"},
                new Status {Id = 2, Name = "Done"}
            );

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo {Id = 1, description = "Do the dishes", DueDate=DateTime.Now , CategoryId = 2, StatusId = 1},
                new ToDo {Id = 2, description = "Finish the report", DueDate=DateTime.Now, CategoryId = 1, StatusId = 1}
                );

          
        }
    }
}