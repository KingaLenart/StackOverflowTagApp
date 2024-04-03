using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Domain.Abstractions;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;

namespace StackOverflowTagApp.Core.Application.Services;

public class TagsReadService
{
    private readonly ITagReadRepository _tagsReadRepository;
    private readonly IMapper<TagEntity, TagOutDto> _tagMapper;

    public TagsReadService(ITagReadRepository readRepository , IMapper<TagEntity, TagOutDto> tagMapper)
    {
        _tagsReadRepository = readRepository;
        _tagMapper = tagMapper;
    }

    public async Task<PagedCollectionOutDto<TagOutDto>> GetTagsPageAsync(SortPagingInfo sortPagingInfo)
    {
        if (sortPagingInfo.PageNumber <= 0)
        {
            throw new ArgumentException("Invalid page number. Please enter a value greater than zero to proceed.");
        }

        var orderBy = sortPagingInfo.OrderBy.ToLower();

        if(!string.IsNullOrWhiteSpace(orderBy) && !(orderBy == "name" || orderBy == "percentageoftags"))
        {
            throw new ArgumentException("The 'orderBy' parameter value is not supported. Please use 'name' or 'percentageoftags' for sorting.");
        }

        var list = await _tagsReadRepository.GetPagedTagsAsync(sortPagingInfo);
        var mappedList = list.Select(_tagMapper.Map).ToList();
        var totalCount = await _tagsReadRepository.GetTotalCountAsync();

        var pageCollectionOutDto = new PagedCollectionOutDto<TagOutDto>
        {
            PageNumber = sortPagingInfo.PageNumber,
            PageSize = sortPagingInfo.PageSize,
            TotalCount = totalCount,
            TotalPage = (int)Math.Ceiling((double)totalCount / sortPagingInfo.PageSize),
            Collection = mappedList
        };

        return pageCollectionOutDto;
    }
}
