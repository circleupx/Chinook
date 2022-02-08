using System.Collections.Generic;

public class EntityCollectionResult<TEntity> where TEntity : class
{
    public int Count {get; }
    public IEnumerable<TEntity> Value { get;}

    public EntityCollectionResult(int count, IEnumerable<TEntity> value)
    {
        Count = count;
        Value = value;
    }
}