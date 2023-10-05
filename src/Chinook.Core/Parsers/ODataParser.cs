using System.Linq;
using System.Linq.Expressions;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;

public static class ODataParser
{
    private static char SingleQuote => '\'';
    private static readonly char[] InvalidStringCharacters = { '*', '=', '+', '$', '#', '~', '`', '\'' };

    public static TextParser<string> ODataString =>
    from start in Character.EqualTo(SingleQuote)
    from chars in Content
    from end in Character.EqualTo(SingleQuote)
    select chars;

    public static TextParser<char> Characters =>
    from c in Character.ExceptIn(InvalidStringCharacters)
    select c;

    public static TextParser<string> Content =>
    from content in Characters.Many()
    select new string(content);

    internal static TextParser<bool> ODataTrue =>
    from chars in Span.EqualToIgnoreCase(ODataKeyWords.True)
    select true;

    internal static TextParser<bool> ODataFalse =>
    from chars in Span.EqualToIgnoreCase(ODataKeyWords.False)
    select false;

    public static TextParser<char> IllegalCharacters =>
    from illegalCharacter in Character.ExceptIn(InvalidStringCharacters)
    select illegalCharacter;

    internal static TextParser<ExpressionType> ODataLogicalAnd =>
    from andOperator in Span.EqualToIgnoreCase(ODataKeyWords.And)
    select ExpressionType.AndAlso;

    internal static TextParser<ExpressionType> ODataLogicalOr =>
    from orOperator in Span.EqualToIgnoreCase(ODataKeyWords.Or)
    select ExpressionType.OrElse;

    internal static TextParser<ExpressionType> ODataEqualOperator =>
    from equalsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Eq)
    select ExpressionType.Equal;

    internal static TextParser<ExpressionType> ODataNotEqualOperator =>
    from equalsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Nq)
    select ExpressionType.NotEqual;

    internal static TextParser<ExpressionType> ODataGreaterThanOperator =>
    from equalsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Gt)
    select ExpressionType.GreaterThan;

    internal static TextParser<ExpressionType> ODataLessThanOperator =>
    from equalsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Lt)
    select ExpressionType.LessThan;

    internal static TextParser<ExpressionType> ODataGreaterThanOrEqualOperator =>
    from equalsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Ge)
    select ExpressionType.GreaterThanOrEqual;

    internal static TextParser<ExpressionType> ODataLessThanOrEqualOperator =>
    from equalsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Le)
    select ExpressionType.LessThanOrEqual;

    internal static TextParser<ExpressionType> ContainsOperator =>
    from containsOperator in Span.EqualToIgnoreCase(ODataKeyWords.Contains)
    select ExpressionType.Call;
}
