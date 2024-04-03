using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;
using StackOverflowTagApp.Core.SQL;

namespace StackOverflowTagApp.Core.Infrastructure.Repositories;
public class TagWriteRepository
{
    private readonly DbSet<TagEntity> tagDbSet;
    private readonly ApplicationDbContext _context;
    private readonly IMapper<StackOverflowTag, double, TagEntity> _tagMapper;

    public TagWriteRepository(ApplicationDbContext context, IMapper<StackOverflowTag, double, TagEntity> tagMapper)
    {
        _context = context;
        _tagMapper = tagMapper;
        tagDbSet = _context.Set<TagEntity>();
    }

    public async Task CreateTagAsync(List<StackOverflowTag> stackOverflowTags)
    {
        var populationSum = stackOverflowTags.Sum(tag => tag.Count);
        var tagEntities = stackOverflowTags.Select(tag => _tagMapper.Map(tag, populationSum));

        var existingTagEntities = await tagDbSet.ToListAsync();

        tagDbSet.RemoveRange(existingTagEntities);
        tagDbSet.AddRange(tagEntities);
        await _context.SaveChangesAsync();
    }
}
