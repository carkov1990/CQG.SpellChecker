using System;

namespace CQG.SpellChecker.Interfaces
{
    /// <summary>
    /// Интерфейс орфографического редактора.
    /// </summary>
    public interface ISpellChecker : IDisposable
    {
        /// <summary>
        /// Метод проверки орфографии.
        /// </summary>
        void Check();
    }
}