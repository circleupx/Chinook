using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Superpower;
using Superpower.Parsers;
using Superpower.Tokenizers;

internal class TokenizerBuilder
{
    private static readonly BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    /// <summary>Tokenize an array of properties using reflection. Ignores casing</summary>
    /// <typeparam name="TObject">Object from which the properties will be extracted.</typeparam>
    /// <returns>Tokenize list of <see cref="TObject"/> properties </returns>
    internal static Tokenizer<ODataTokens> TokenizeObjectProperties<TObject>()
    {
        var tokenizer = Tokenizers.GetODataTokenizer();
        var mappedPropertiesToToken = MapPropertiesToToken<TObject>(tokenizer);
        return mappedPropertiesToToken.Build();
    }

    /// <summary>Tokenize an array of properties using reflection.</summary>
    /// <typeparam name="TObject1">Object from which the properties will be extracted.</typeparam>
    /// <typeparam name="TObject2">Object from which the properties will be extracted.</typeparam>
    /// <returns>Tokenize list of <see cref="TObject1"/> and <see cref="TObject2"/>properties </returns>
    internal static Tokenizer<ODataTokens> TokenizeObjectProperties<TObject1, TObject2>()
    {
        var tokenizer = Tokenizers.GetODataTokenizer();
        var mapPropertiesToToken = MapPropertiesToToken<TObject1, TObject2>(tokenizer);
        return mapPropertiesToToken.Build();
    }

    private static TokenizerBuilder<ODataTokens> MapPropertiesToToken<TObject>(TokenizerBuilder<ODataTokens> tokenizer)
    {
        IEnumerable<string> properties = typeof(TObject)
            .GetProperties(Flags)
                .Select(propertyInfo => propertyInfo.Name)
                    .Distinct();

        foreach (var propertyName in properties)
        {
            tokenizer.Match(Span.EqualToIgnoreCase(propertyName), ODataTokens.ObjectField);
        }

        return tokenizer;
    }

    private static TokenizerBuilder<ODataTokens> MapPropertiesToToken<TObject1, TObject2>(TokenizerBuilder<ODataTokens> tokenizer)
    {
        var firstModelProperties = typeof(TObject1).GetProperties(Flags);
        var secondModelProperties = typeof(TObject2).GetProperties(Flags);
        IEnumerable<string> properties = firstModelProperties
            .Concat(secondModelProperties)
                .Select(p => p.Name)
                    .Distinct();

        foreach (var propertyName in properties)
        {
            tokenizer.Match(Span.EqualToIgnoreCase(propertyName), ODataTokens.ObjectField);
        }

        return tokenizer;
    }
}
