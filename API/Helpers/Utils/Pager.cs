

namespace API.Helpers;
public class Pager<T> where T : class
{    
    
    public int CurrentPage { get; set; } // pagina actual
    public int PageSize { get; set; } // cantidad de registros por pagina
    public int TotalCount { get; set; } // cantidad total de registros
    
    public string Search { get; private set; } // busqueda
    public IEnumerable<T> Items { get; set; } // lista de registros

    public Pager(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize, string search)
    {
        Items = items;
        TotalCount = totalCount;
        CurrentPage = pageIndex;
        PageSize = pageSize;
        Search = search;
        // TotalCount = count;
    }

    public int TotalPages
    {
        get
        {
            return (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
    }

    public bool HasPrevious
    {
        get
        {
            return CurrentPage > 1;
        }
    }

    public bool HasNext
    {
        get
        {
            return CurrentPage < TotalPages;
        }
    }



}