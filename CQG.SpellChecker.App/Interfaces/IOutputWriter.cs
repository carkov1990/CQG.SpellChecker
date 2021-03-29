using System;

namespace CQG.SpellChecker.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с результатом.
    /// </summary>
    public interface IOutputWriter : IDisposable
    {
        /// <summary>
        /// Метод записи строки в выходной поток.
        /// </summary>
        /// <param name="line">Строка.</param>
        void WriteLine(string line);
    }
}