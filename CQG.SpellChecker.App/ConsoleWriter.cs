using System;
using CQG.SpellChecker.Interfaces;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс вывода в консоль.
    /// </summary>
    public class ConsoleWriter : IOutputWriter
    {
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
        }

        /// <inheritdoc cref="IOutputWriter.WriteLine"/>
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}