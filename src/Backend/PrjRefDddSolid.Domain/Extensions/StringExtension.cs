using System.Diagnostics.CodeAnalysis;

namespace PrjRefDddSolid.Domain.Extensions;

public static class StringExtension
{
    public static bool IsEmpty([NotNullWhen(false)] this string? values)
    {
        return string.IsNullOrWhiteSpace(values);
    }

    public static bool IsNotEmpty([NotNullWhen(true)] this string? values)
    {
        return !string.IsNullOrWhiteSpace(values);
    }
}
