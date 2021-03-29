using System;
using CQG.SpellChecker.Interfaces;
using CQG.SpellChecker.Models;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс менеджера аргументов
    /// </summary>
    public class ArgumentManager : IArgumentManager
    {
        private readonly Options _options;

        /// <summary>
        /// .ctor
        /// </summary>
        public ArgumentManager(Options options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }
        
        /// <inheritdoc cref="IArgumentManager.GetInputArgument"/>
        public string GetInputArgument()
        {
            return _options.Input;
        }

        /// <inheritdoc cref="IArgumentManager.GetOutputArgument"/>
        public string GetOutputArgument()
        {
            return _options.Output;
        }
    }
}