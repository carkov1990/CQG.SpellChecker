using System;
using System.IO;
using CQG.SpellChecker.Interfaces;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс записи результата в файл.
    /// </summary>
    public class FileWriter : IOutputWriter
    {
        private readonly StreamWriter _streamWriter; 
        
        /// <summary>
        /// .ctor
        /// </summary>
        public FileWriter(IArgumentManager argumentManager)
        {
            _ = argumentManager ?? throw new ArgumentNullException(nameof(argumentManager));
            var filePath = argumentManager.GetOutputArgument() ?? throw new ArgumentNullException("Path outputfile is null.");
            _streamWriter = new StreamWriter(filePath);
        }
        
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            _streamWriter?.Dispose();
        }

        /// <inheritdoc cref="IOutputWriter.WriteLine"/>
        public void WriteLine(string line)
        {
            _streamWriter.WriteLine(line);
        }
    }
}