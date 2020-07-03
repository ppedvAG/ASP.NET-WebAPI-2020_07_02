using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.MVC.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext (DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo.Domain.Entities.Blog> Blog { get; set; }

        public DbSet<Todo.Domain.Entities.Comment> Comment { get; set; }
    }
}
