namespace StackOverflowTagApp.Core.Application.Models;

public class PagingRequestModel
{
    const int maxPageSize = 10;

    public int PageNumber { get; set; }

    private int pageSize;
    public int PageSize
    {
        get
        {
            return pageSize;
        }
        set
        {
            pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
    public string OrderBy { get; set; }

    public SortDirection? SortDirection { get; set; }
}
