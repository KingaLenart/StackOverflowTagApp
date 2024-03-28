using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowTagApp.Core.Models;

namespace StackOverflowTagApp.Core.SQL.Configuration
{
    internal class TagConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(t => t.TagId);
        }
    }
}
