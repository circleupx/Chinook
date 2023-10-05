using System;
using System.Collections.Generic;
using System.Linq;
using Chinook.Core.Builders;
using Humanizer;
using Superpower.Model;

namespace Chinook.Core
{
    public sealed class ResourceQueryBuilder :
        IResourceQueryBuilder,
        IStartResourceFiltering,
        IAddResourceFiltering,
        IEndResourceFiltering,
        IStartResourceSort,
        IAddResourceSorting,
        IEndResourceSorting,
        IStartResoucePagination,
        IAddResourcePagination,
        IEndResourcePagination,
        IStartIncludeResource,
        IAddIncludedResources,
        IEndResourceInclude
    {
        private static QueryParameterService _queryParameterService;

        private IDictionary<string, dynamic> keyValuePairs = new Dictionary<string, dynamic>();

        private ResourceQueryBuilder()
        {
            // Prevent default constructor calls
        }

        public static IResourceQueryBuilder NewResourceQuerySpecification(Uri requestUri)
        {
            _queryParameterService = new QueryParameterService(requestUri);
            return new ResourceQueryBuilder();
        }

        public IAddResourceFiltering AddFilter<TResource>()
        {
            var tokenizer = TokenizerBuilder.TokenizeObjectProperties<TResource>();
            var parsedQueryStringDictionary = _queryParameterService.ParseFilterQueryString();
            var resourceType = typeof(TResource);

            // The API uses Camel Casing, convert the key and pluralize it's name to match on the resource being filtered.
            var resource = parsedQueryStringDictionary.FirstOrDefault(x => x.Key.Camelize() == resourceType.Name.Camelize().Pluralize());
            if (resource.Key is null)
            {
                keyValuePairs.Add(resourceType.Name, PredicateBuilder.New<TResource>());
                return this;
            }
            
            // TryTokenize will return parsing error, this error could be converted into a JSON:API Errors Document.
            var result = tokenizer.TryTokenize(resource.Value);
            var tokenList = result.Value;

            var visitor = new ExpressionTreeVisitor<TResource>();
            foreach (var token in tokenList)
            {
                switch (token.Kind)
                {
                    case ODataTokens.None:
                        break;
                    case ODataTokens.StringValue:
                        VisitConstantNode(token, visitor);
                        break;
                    case ODataTokens.BooleanValue:
                        VisitConstantNode(token, visitor);
                        break;
                    case ODataTokens.ObjectField:
                        VisitObjectField(token, visitor, resourceType);
                        break;
                    case ODataTokens.LogicalOperator:
                        VisitLogicalNode(token, visitor);
                        break;
                    case ODataTokens.ComparisonOperator:
                        VisitComparisonNode(token, visitor);
                        break;
                    case ODataTokens.IntegerValue:
                        VisitConstantNode(token, visitor);
                        break;
                }
            }

            var filter = visitor.GetFilterExpression();
            keyValuePairs.Add(resourceType.Name, filter);
            return this;
        }

        public IAddIncludedResources AddInclude(string queryParamter)
        {
            return this;
        }

        public IAddResourcePagination AddPagination(int pageNumber = 1, int pageSize = 50, int maxPageSize = 100)
        {
            return this;
        }

        public IAddResourceSorting AddSort(string sortQueryParamter)
        {
            return this;
        }

        public IEndResourceInclude EndInclude()
        {
            return this;
        }

        public IEndResourcePagination EndPagination()
        {
            return this;
        }

        public IEndResourceSorting EndSorting()
        {
            return this;
        }

        public IStartResourceFiltering StartFilter()
        {
            return this;
        }

        public IStartIncludeResource Include()
        {
            return this;
        }

        public IStartResoucePagination Paginate()
        {
            return this;
        }

        public IStartResourceSort Sort()
        {
            return this;
        }

        public IStartResourceFiltering StartFilters()
        {
            return this;
        }

        public IStartIncludeResource StartInclude()
        {
            return this;
        }

        public IStartResoucePagination StartPagination()
        {
            return this;
        }

        public IStartResourceSort StartSorting()
        {
            return this;
        }

        public IEndResourceFiltering EndFilter()
        {
            return this;
        }

        public ResoureQuerySpecification BuildSpecification()
        {
            var resoureQuerySpecification = new ResoureQuerySpecification();
            foreach(var v in keyValuePairs)
            {
                resoureQuerySpecification.AddFilter(v.Key, v.Value);
            }
            return resoureQuerySpecification;
        }

        private static void VisitConstantNode(Token<ODataTokens> token, IAbstractSyntaxTreeVisitor visitor)
        {
            var node = new ValueNode(token.ToStringValue());
            node.Accept(visitor);
        }

        private static void VisitObjectField(Token<ODataTokens> token, IAbstractSyntaxTreeVisitor visitor, Type resourceType)
        {
            var node = new FieldNode(token.ToStringValue(), resourceType);
            node.Accept(visitor);
        }

        private static void VisitComparisonNode(Token<ODataTokens> token, IAbstractSyntaxTreeVisitor visitor)
        {
            var node = new OperatorNode(token.ToStringValue());
            node.Accept(visitor);
        }

        private static void VisitLogicalNode(Token<ODataTokens> token, IAbstractSyntaxTreeVisitor visitor)
        {
            var node = new OperatorNode(token.ToStringValue());
            node.Accept(visitor);
        }
    }
}