using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Domain.Abstractions;
using StackOverflowTagApp.Core.SQL;

namespace StackOverflowTagApp.Core.Infrastructure.Repositories;

internal class TagReadRepository : ITagReadRepository
{
    private readonly DbSet<TagEntity> _tags;

    public TagReadRepository(ApplicationDbContext context)
    {
        _tags = context.Set<TagEntity>();
    }

    public async Task<IEnumerable<TagEntity>> GetPagedTagsAsync(SortPagingInfo pagingInfo)
    {
        var query = _tags.AsQueryable();

        switch (pagingInfo.OrderBy?.ToLower())
        {
            case "name":
                query = pagingInfo.SortDirection == SortDirection.Ascending
                    ? query.OrderBy(t => t.Name)
                    : query.OrderByDescending(t => t.Name);
                break;

            case "percentageOfTags":
                query = pagingInfo.SortDirection == SortDirection.Ascending
                    ? query.OrderBy(t => t.PercentageOfTags)
                    : query.OrderByDescending(t => t.PercentageOfTags);
                break;
        }

        return await query
            .Skip((pagingInfo.PageNumber - 1) * 100)
            .Take(pagingInfo.PageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _tags.AsQueryable().CountAsync();
    }
}
