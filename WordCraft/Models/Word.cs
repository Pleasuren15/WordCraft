using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using WordCraft.Models.Enums;
using WordCraft.Models.Validations;

namespace WordCraft.Models;

[WordValidation]
[ExcludeFromCodeCoverage]
public class Word
{
    [JsonPropertyName(nameof(FullWord))]
    public string FullWord { get; set; } = string.Empty;

    [JsonPropertyName(nameof(Length))]
    public int Length { get; set; }

    [JsonPropertyName(nameof(Category))]
    public Category Category { get; set; }

    [JsonPropertyName(nameof(Langauge))]
    public LanguageCode Langauge { get; set; }
}
