namespace StackOverflowTagApp.Core.Domain;

public class SortPagingInfo
{
    const int maxPageSize = 100;
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
