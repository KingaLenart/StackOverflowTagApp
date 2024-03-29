using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Models;
using StackOverflowTagApp.Core.SQL.Configuration;

namespace StackOverflowTagApp.Core.SQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
