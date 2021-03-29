namespace CQG.SpellChecker.Interfaces
{
    /// <summary>
    /// Интерфейс для работы со словарем.
    /// </summary>
    public interface IDictionary
    {
        /// <summary>
        /// Метод заполнения словаря.
        /// </summary>
        /// <param name="words">Последовательность словарных слов.</param>
        void FillDictionary(string[] words);

        /// <summary>
        /// Метод проверки вхождения слова в словарь.
        /// </summary>
        /// <param name="word">Искомое слово.</param>
        bool ContainsWord(string word);

        /// <summary>
        /// Метод получения наиболее подходящих слов из словаря.
        /// </summary>
        /// <param name="word">Искомое слово.</param>
        string[] GetDictionaryValuesByWord(string word);
    }
}