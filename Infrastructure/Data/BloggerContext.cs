using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BloggerContext : DbContext
    {
        public BloggerContext(DbContextOptions options) : base(options){ }
        public DbSet<Post> Posts { get; set; }
    }
}
