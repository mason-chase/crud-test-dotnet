namespace Application.Common.Models;

public class PaginatedList<T>
{
    public List<T> Items { get; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public PaginatedList(List<T> items,int currentPage, int count, int pageSize)
    {
        CurrentPage = currentPage;
        PageSize= pageSize;
        PageCount = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPrevious => CurrentPage > 1 && PageCount > 1;

    public bool HasNext => CurrentPage < PageCount;

    public int FirstRowOnPage=> (CurrentPage - 1) * PageSize + 1; 

    public int LastRowOnPage=> Math.Min(CurrentPage * PageSize, TotalCount);

}
