using System.Collections;
using System.Collections.Generic;

namespace CQG.SpellChecker.Interfaces
{
    /// <summary>
    /// Интерфейс читателя входящего файла.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Метод получения словарных слов.
        /// </summary>
        string[] GetDictionaryWords();
        
        /// <summary>
        /// Метод получения текста.
        /// </summary>
        IEnumerable<string> GetTextLines();
    }
}