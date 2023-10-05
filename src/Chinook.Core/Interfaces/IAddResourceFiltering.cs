namespace Chinook.Core
{
    public interface IAddResourceFiltering
    {
        IAddResourceFiltering AddFilter<TResource>();
        IEndResourceFiltering EndFilter();
    }
}

