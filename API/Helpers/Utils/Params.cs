

namespace API.Helpers;
public class Params
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;
    private int _pageNumber = 1;

    private string _search;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = (value <= 0) ? 1 : value;
    }

    public string Search
    {
        get => _search;
        set => _search = (!string.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }

}