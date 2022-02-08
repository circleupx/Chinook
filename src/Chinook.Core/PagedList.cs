using System;

public class PagedList
{
    public PagedList(int recordCount, int pageNumber, int pageSize)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        RecordCount = recordCount;
    }

    private int PageSize { get; }
    private int PageNumber { get; }
    private int RecordCount { get; }
    private int NumberOfPages => (int)Math.Ceiling(RecordCount / (double)PageSize);
    private bool HasAPreviousPage => PageNumber > 1;
    private bool HasANextPage => PageNumber < NumberOfPages;

    public bool HasNextPage()
    {
        return HasANextPage;
    }

    public bool HasPreviousPage()
    {
        return HasAPreviousPage;
    }

    public int GetPageSize()
    {
        return PageSize;
    }

    public int GetNextPageNumber()
    {
        return PageNumber + 1;
    }

    public int GetPreviousPageNumber()
    {
        return PageNumber - 1;
    }

    public int GetFirstPageNumber()
    {
        return 1;
    }

    public int GetLastPageNumber()
    {
        return NumberOfPages;
    }
}