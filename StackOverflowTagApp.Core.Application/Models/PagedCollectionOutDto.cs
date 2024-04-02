namespace StackOverflowTagApp.Core.Application.Models;

public class PagedCollectionOutDto<T>
{
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }

    public ICollection<T> Collection { get; set; }
}
