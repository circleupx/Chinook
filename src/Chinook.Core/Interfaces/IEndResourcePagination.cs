namespace Chinook.Core
{
    public interface IEndResourcePagination
    {
        IStartResourceFiltering StartFilters();
        IStartResourceSort StartSorting();
        IStartIncludeResource StartInclude();
        ResoureQuerySpecification BuildSpecification();
    }
}

