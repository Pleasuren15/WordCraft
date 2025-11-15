using WordCraft.Models;
using WordCraft.Models.Enums;

namespace WordCraft.Services
{
    public interface IWordService
    {
        IEnumerable<Word> GetRandomWords(
            Alphabet startingAlphabet = Alphabet.All,
            LanguageCode languageCode = LanguageCode.en,
            Category category = Category.All,
            WordCase wordCase = WordCase.Lower,
            int wordLength = 15,
            int numberOfWords = 20);
    }
}