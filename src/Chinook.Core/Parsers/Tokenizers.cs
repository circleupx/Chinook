using Superpower.Parsers;
using Superpower.Tokenizers;

public static class Tokenizers
{
    public static TokenizerBuilder<ODataTokens> GetODataTokenizer()
    {
        var tokenizerBuilder = new TokenizerBuilder<ODataTokens>()
            .Ignore(Span.WhiteSpace)
            .Match(ODataParser.ODataEqualOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ODataNotEqualOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ODataGreaterThanOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ODataLessThanOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ODataGreaterThanOrEqualOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ODataLessThanOrEqualOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ContainsOperator, ODataTokens.ComparisonOperator)
            .Match(ODataParser.ODataString, ODataTokens.StringValue)
            .Match(ODataParser.ODataLogicalAnd, ODataTokens.LogicalOperator)
            .Match(ODataParser.ODataLogicalOr, ODataTokens.LogicalOperator)
            .Match(ODataParser.ODataFalse, ODataTokens.BooleanValue)
            .Match(ODataParser.ODataTrue, ODataTokens.BooleanValue)
            .Match(Numerics.IntegerInt32, ODataTokens.IntegerValue);
        return tokenizerBuilder;
    }
}