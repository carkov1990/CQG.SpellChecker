namespace CQG.SpellChecker.Interfaces
{
    /// <summary>
    /// Интерфейс редактора.
    /// </summary>
    public interface IEditor
    {
        /// <summary>
        /// Метод результата редактирования.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <param name="dictionaryWords">Словарные слова.</param>
        string Edit(string word, string[] dictionaryWords);
    }
}