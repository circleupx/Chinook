namespace Chinook.Core
{
    public interface IEndResourceSorting
    {
        IStartResourceFiltering StartFilters();
        IStartResoucePagination StartPagination();
        IStartIncludeResource StartInclude();
        ResoureQuerySpecification BuildSpecification();
    }
}

