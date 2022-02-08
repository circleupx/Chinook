using System;
using System.Linq.Expressions;

public interface IEntityQuerySpecification<TEntity>
{
    Expression<Func<TEntity, bool>> FilterExpression { get; }
    int Take {get;}
    int Skip {get;}
}