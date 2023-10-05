using System;
using Chinook.Core.Models;
using Xunit;

namespace Chinook.Core.Test
{
    public class Parser
    {
        [Fact]
        public void Test()
        {
            var u = new Uri("https://google.com/posts?filter[Album]=Title eq 'Yunier'&filter[Artist]=Name eq 'Dan'&include=Artist");
            var resource = ResourceQueryBuilder
            .NewResourceQuerySpecification(u)
                .StartFilter()
                    .AddFilter<Album>()
                .EndFilter()
            .BuildSpecification();

            var a = resource.FilterExpressions;
        }
    }
}