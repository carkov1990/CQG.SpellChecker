using System;
using System.Collections.Generic;
using System.IO;
using CQG.SpellChecker.Interfaces;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс читателя данных из файла.
    /// </summary>
    public class FileInputReader : IInputReader
    {
        private const string EndTextBlock = "===";
        private readonly string _filePath; 
        
        /// <summary>
        /// .ctor
        /// </summary>
        public FileInputReader(IArgumentManager argumentManager)
        {
            _filePath = argumentManager?.GetInputArgument() ?? throw new ArgumentNullException(nameof(argumentManager));
        }
        
        /// <inheritdoc cref="IInputReader.GetDictionaryWords"/>
        public string[] GetDictionaryWords()
        {
            var dictionaryWords = new List<string>();
            using (var sr = new StreamReader(_filePath))
            {
                var line = sr.ReadLine();
                while (line != null && line != EndTextBlock)
                {
                    dictionaryWords.AddRange(line.Split(' '));
                    line = sr.ReadLine();
                }
            }

            return dictionaryWords.ToArray();
        }

        /// <inheritdoc cref="IInputReader.GetTextLines"/>
        public IEnumerable<string> GetTextLines()
        {
            using var sr = new StreamReader(_filePath);
            var line = sr.ReadLine();
            while (line != null && line != EndTextBlock)
            {
                line = sr.ReadLine();
            }
                
            line = sr.ReadLine();
            while (line != null && line != EndTextBlock)
            {
                yield return line;
                line = sr.ReadLine();
            }
        }
    }
}