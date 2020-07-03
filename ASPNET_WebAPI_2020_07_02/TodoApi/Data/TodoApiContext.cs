using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace TodoApi.Data
{
    public class TodoApiContext : DbContext
    {
        public TodoApiContext (DbContextOptions<TodoApiContext> options)
            : base(options)
        {
        }

        public DbSet<Todo.Domain.Entities.Blog> Blog { get; set; }
    }
}
