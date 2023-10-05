namespace Chinook.Core
{
    public interface IStartResoucePagination
    {
        IAddResourcePagination AddPagination(int pageNumber = 1, int pageSize = 50, int maxPageSize = 100);
    }
}

