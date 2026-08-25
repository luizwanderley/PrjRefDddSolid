using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace PrjRefDddSolid.Api.Converters;

public partial class StringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        //                    nome                    sobrenome                

        var value = reader.GetString()?.Trim();

        if (value is null)
            return value;

        //nome                 sobrenome

        return RemoveExtraBlankSpace().Replace(value, " ");

        //retorna nome sobrenome, com apenas um espaço entre eles, removendo espaços extras no início, no final e entre as palavras
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveExtraBlankSpace();
}
