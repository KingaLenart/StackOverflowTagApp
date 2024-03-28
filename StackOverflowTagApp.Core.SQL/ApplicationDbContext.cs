using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Models;

namespace StackOverflowTagApp.Core.SQL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TagEntity> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }
    }
}
