namespace Chinook.Core
{
    public interface IEndResourceFiltering
    {
        IStartResourceSort StartSorting();
        IStartResoucePagination StartPagination();
        IStartIncludeResource StartInclude();
        ResoureQuerySpecification BuildSpecification();
    }
}

