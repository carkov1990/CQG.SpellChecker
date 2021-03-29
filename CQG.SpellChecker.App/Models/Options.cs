using System.IO;
using CommandLine.Attributes;

namespace CQG.SpellChecker.Models
{
    /// <summary>
    /// Модель аргументов.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Путь до входящего файла.
        /// </summary>
        [RequiredArgument(0,"inputFile", "Path to input file")]
        public string Input { get; set; }

        /// <summary>
        /// Аргумент исходящего потока. Если отсутствует, значит результат выводится на консоль.
        /// </summary>
        [OptionalArgument(null, "outputFile", "Output file path. If argument is null result will be printed to the console.")]
        public string Output { get; set; }

        /// <summary>
        /// Метод валидации параметров
        /// </summary>
        public bool IsValid()
        {
            if (!File.Exists(Input))
            {
                return false;
            }

            return true;
        }
    }
}