using Microsoft.EntityFrameworkCore;
using StackOverflowTagApp.Core.Application.Mappers;
using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.SQL;

namespace StackOverflowTagApp.Core.Application.Services;

public class TagsReadService
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TagEntity> _tags;
    private readonly TagMapper _tagMapper;

    public TagsReadService(ApplicationDbContext context, TagMapper tagMapper)
    {
        _context = context;
        _tags = _context.Set<TagEntity>();
        _tagMapper = tagMapper;
    }

    public async Task<PagedCollectionOutDto<TagOutDto>> GetTagsPageAsync(PagingRequestModel pagingRequestModel)
    {
        if (pagingRequestModel.PageNumber <= 0)
        {
            throw new Exception("Invalid page number. Please enter a value greater than zero to proceed.");
        }

        var query = _tags.AsQueryable();

        switch (pagingRequestModel.OrderBy?.ToLower())
        {
            case "name":

                query = pagingRequestModel.SortDirection == SortDirection.Ascending
                    ? query.OrderBy(t => t.Name)
                    : query.OrderByDescending(t => t.Name);
                break;

            case "percentageOfTags":

                query = pagingRequestModel.SortDirection == SortDirection.Ascending
                    ? query.OrderBy(t => t.PercentageOfTags)
                    : query.OrderByDescending(t => t.PercentageOfTags);
                break;

        }

        var list = await query
            .Skip((pagingRequestModel.PageNumber - 1) * 100)
            .Take(pagingRequestModel.PageSize)
            .ToListAsync();

        var mappedList = list.Select(_tagMapper.MapTag).ToList();

        var totalCount = await query.CountAsync();

        var pageCollectionOutDto = new PagedCollectionOutDto<TagOutDto>
        {
            PageNumber = pagingRequestModel.PageNumber,
            PageSize = pagingRequestModel.PageSize,
            TotalCount = totalCount,
            TotalPage = totalCount / pagingRequestModel.PageSize,
            Collection = mappedList
        };

        return pageCollectionOutDto;

    }
}
