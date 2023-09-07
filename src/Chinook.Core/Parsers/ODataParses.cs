using System.Linq;
using Superpower;
using Superpower.Parsers;

public static class ODataParser
{
    private static char SingleQuote => '\'';
    private static readonly char[] InvalidStringCharacters = {'*', '=', '+', '$', '#', '~', '`', '\'', ' '};

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
}