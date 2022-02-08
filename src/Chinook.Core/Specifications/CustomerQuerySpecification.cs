using System;
using System.Linq.Expressions;
using Chinook.Core.Models;

public class CustomerQuerySpecification : IEntityQuerySpecification<Customer>
{
    public Expression<Func<Customer, bool>> FilterExpression { get; } = entity => true; // result in no SQL generated

    public int Take { get; }

    public int Skip { get; }

    public CustomerQuerySpecification(UriQueryParametersReader uriQueryParametersReader)
    {
        var pageNumber = uriQueryParametersReader.GetPageNumberFromRequestUri();
        var pageSize = uriQueryParametersReader.GetSizeNumberFromRequestUri();

        Take = pageSize;
        Skip = (pageNumber - 1) * pageSize;
    }
}