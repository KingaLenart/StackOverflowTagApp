using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Models;

namespace StackOverflowTagApp.Core.SQL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TypicalTagEntity> Tags { get; set; }
        public DbSet<UserTagEntity> UserTags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }
    }
}
