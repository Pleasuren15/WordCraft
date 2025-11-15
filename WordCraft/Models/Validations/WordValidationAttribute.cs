using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WordCraft.Models.Validations;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class)]
public class WordValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var word = value as Word;

        if (string.IsNullOrEmpty(word!.FullWord))
        {
            return new ValidationResult("Validation Failure: FullWord Cannot Be Null Or Empty");
        }

        return ValidationResult.Success!;
    }
}
