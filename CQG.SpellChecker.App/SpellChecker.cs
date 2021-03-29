using System;
using System.Text;
using CQG.SpellChecker.Interfaces;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс проверки орфографии.
    /// </summary>
    public class SpellChecker : ISpellChecker, IDisposable
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private readonly IDictionary _dictionary;
        private readonly IEditor _editor;
        
        /// <summary>
        /// .ctor
        /// </summary>
        public SpellChecker(IInputReader inputReader, IOutputWriter outputWriter, IDictionary dictionary, IEditor editor)
        {
            _inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
            _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            _editor = editor ?? throw new ArgumentNullException(nameof(editor));
            _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
            
            _dictionary.FillDictionary(_inputReader.GetDictionaryWords());
        }
        
        /// <inheritdoc cref="ISpellChecker.Check"/>
        public void Check()
        {
            foreach (var textLine in _inputReader.GetTextLines())
            {
                StringBuilder sb = new StringBuilder(textLine.Length);
                if (!string.IsNullOrWhiteSpace(textLine))
                {
                    var textWords = textLine.Split(' ');
                    foreach (var textWord in textWords)
                    {
                        if (_dictionary.ContainsWord(textWord))
                        {
                            sb.Append($"{textWord} ");
                        }
                        else
                        {
                            var dictionaryWords = _dictionary.GetDictionaryValuesByWord(textWord);
                            sb.Append($"{_editor.Edit(textWord, dictionaryWords)} ");
                        }
                    }
                    _outputWriter.WriteLine(sb.ToString().TrimEnd(' ')); }
                else
                {
                    return;
                }
            }
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            _outputWriter?.Dispose();
        }
    }
}