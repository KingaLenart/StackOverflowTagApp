using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Models;
using StackOverflowTagApp.Core.Services.Models;
using StackOverflowTagApp.Core.SQL;

namespace StackOverflowTagApp.Core.Services.Implementations
{

    public class TagWriteRepository
    {
        private readonly DbSet<TagEntity> tagDbSet;
        private readonly ApplicationDbContext _context;
        private readonly TagMapper tagMapper;

        public TagWriteRepository(ApplicationDbContext context, TagMapper tagMapper)
        {
            _context = context;
            this.tagMapper = tagMapper;
            tagDbSet = _context.Set<TagEntity>();
        }

        public async Task TagCreateAsync(List<StackOverflowTag> stackOverflowTags)
        {
            var populationSum = stackOverflowTags.Sum(tag => tag.Count);
            var tagEntities = stackOverflowTags.Select(tag => tagMapper.MapTag(tag, populationSum));

            var existingTagEntities = await tagDbSet.ToListAsync();

            tagDbSet.RemoveRange(existingTagEntities);
            tagDbSet.AddRange(tagEntities);
            await _context.SaveChangesAsync();
        }
    }
}
