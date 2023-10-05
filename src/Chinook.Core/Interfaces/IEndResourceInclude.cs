namespace Chinook.Core
{
    public interface IEndResourceInclude
    {
        IStartResourceFiltering StartFilters();
        IStartResourceSort StartSorting();
        IStartResoucePagination StartPagination();
        ResoureQuerySpecification BuildSpecification();
    }
}

