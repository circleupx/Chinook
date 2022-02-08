public static class UriKeyWords
{
    public static string PageNumber = $"page[{number}]";
    public static string PageSize = $"page[{size}]";
    public const string size = nameof(size);
    public const string number = nameof(number);
}