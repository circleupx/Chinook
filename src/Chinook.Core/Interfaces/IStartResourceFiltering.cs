namespace Chinook.Core
{
    public interface IStartResourceFiltering
    {
        IAddResourceFiltering AddFilter<TResource>();
    }
}

