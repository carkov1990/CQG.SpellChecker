namespace CQG.SpellChecker.Interfaces
{
    /// <summary>
    /// Интерфейс менеджера аргументов
    /// </summary>
    public interface IArgumentManager
    {
        /// <summary>
        /// Метод получения пути входящего файла
        /// </summary>
        string GetInputArgument();
        
        /// <summary>
        /// Метод получения параметра исходящего потока
        /// </summary>
        string GetOutputArgument();
    }
}