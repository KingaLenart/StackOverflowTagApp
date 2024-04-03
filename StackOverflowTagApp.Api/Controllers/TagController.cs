using Microsoft.AspNetCore.Mvc;
using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Application.Services;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Services;

namespace StackOverflowTagApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase
{
    private readonly StackOverflowTagsSyncService _stackOverflowReadTagsService;
    private readonly TagsReadService _tagsReadService;

    public TagController(StackOverflowTagsSyncService stackOverflowReadTagsService, TagsReadService tagsReadService)
    {
        _stackOverflowReadTagsService = stackOverflowReadTagsService;
        _tagsReadService = tagsReadService;
    }

    [HttpPost("sync")]
    public async Task<List<StackOverflowTag>> SyncTags()
    {
        return await _stackOverflowReadTagsService.SyncTagsAsync();
    }

    [HttpPost("paged")]
    public async Task<PagedCollectionOutDto<TagOutDto>> Paged(SortPagingInfo sortPagingInfo)
    {
        return await _tagsReadService.GetTagsPageAsync(sortPagingInfo);
    }
}
