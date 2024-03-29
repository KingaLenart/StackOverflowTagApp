using Microsoft.AspNetCore.Mvc;
using StackOverflowTagApp.Core.Services.Implementations;
using StackOverflowTagApp.Core.Services.Models;

namespace StackOverflowTagApp.Api.Controllers.TypicalTags
{
    [ApiController]
    [Route("[controller]")]
    public class TypicalTagReadController : ControllerBase
    {
        private readonly StackOverflowReadTagsService _stackOverflowReadTagsService;

        public TypicalTagReadController(StackOverflowReadTagsService stackOverflowReadTagsService)
        {
            _stackOverflowReadTagsService = stackOverflowReadTagsService;
        }

        [HttpGet("fetch")]
        public async Task<List<StackOverflowTag>> FetchTags()
        {
           return await _stackOverflowReadTagsService.GetTagsAsync();
        }
    }
}
