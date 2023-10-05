using System;

namespace Chinook.Core
{
    public interface IResourceQueryBuilder
    {
        IStartResourceFiltering StartFilter();
        IStartResourceSort Sort();
        IStartResoucePagination Paginate();
        IStartIncludeResource Include();
        ResoureQuerySpecification BuildSpecification();
    }
}

