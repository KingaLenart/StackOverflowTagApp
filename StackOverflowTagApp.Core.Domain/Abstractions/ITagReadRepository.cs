namespace StackOverflowTagApp.Core.Domain.Abstractions;

public interface ITagReadRepository
{
    Task<IEnumerable<TagEntity>> GetPagedTagsAsync(SortPagingInfo pagingInfo);
    Task<int> GetTotalCountAsync();
}
