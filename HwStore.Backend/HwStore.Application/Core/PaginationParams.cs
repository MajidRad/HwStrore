namespace HwStore.Application.Core;

public class PaginationParams
{

    private static int MaxPageSize = 50;
    private int _pageSize = 10;
    private int _pageNumber = 0;
    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
