using System.Text.Json;
using WordCraft.Models;
using WordCraft.Models.Enums;

namespace WordCraft.Services;

public class WordService : IWordService
{
    public IEnumerable<Word> GetRandomWords(
        Alphabet startingAlphabet = Alphabet.All,
        LanguageCode languageCode = LanguageCode.en,
        Category category = Category.All,
        WordCase wordCase = WordCase.Lower,
        int wordLength = 15,
        int numberOfWords = 20)
    {
        var words = GetWordsFromDataSource(startingAlphabet: startingAlphabet);

        words = category == Category.All ? words : words.Where(word => word.Category == category);
        words = words.Where(word => word.Length <= wordLength).Take(numberOfWords);
        words = wordCase == WordCase.Upper ? words.Select(word => { word.FullWord = word.FullWord.ToUpper(); return word; }) :
                                        words.Select(word => { word.FullWord = word.FullWord.ToLower(); return word; });

        return words;
    }

    /// <summary>
    /// Fetch words from data source based on starting alphabet.
    /// </summary>
    /// <param name="startingAlphabet"></param>
    /// <returns></returns>
    private IEnumerable<Word> GetWordsFromDataSource(Alphabet startingAlphabet)
    {
        var words = new List<Word>();

        var lettersToGet = startingAlphabet.Equals(Alphabet.All) ?
                string.Join(string.Empty, Enum.GetNames<Alphabet>()) :
                startingAlphabet.ToString();

        foreach (var letter in lettersToGet)
        {
            var jsonFilePath = $"{Path.Combine(AppContext.BaseDirectory).Replace("\\bin\\Debug\\net9.0\\", string.Empty)}\\Words\\{letter}-words.json";
            var jsonString = File.ReadAllText(jsonFilePath);
            var wordsFromFile = JsonSerializer.Deserialize<IEnumerable<Word>>(jsonString)!;
            wordsFromFile.ToList().ForEach(word => words.Add(word));
        }

        return words;
    }
}
