using System;
using System.IO;
using CommandLine;
using CQG.SpellChecker.Interfaces;
using CQG.SpellChecker.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Startup class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Startup method
        /// </summary>
        static void Main(string[] args)
        {
            var provider = GetServiceProvider(args);
            if (provider == null)
            {
                return;
            }

            using var spellChecker = provider.GetService<ISpellChecker>();
            try
            {
                spellChecker.Check();
            }
            catch (Exception e)
            {
                WriteErrorMessage(e.Message);
            }
        }

        private static ServiceProvider GetServiceProvider(string[] args)
        {
            var options = GetOptions(args);
            if (options == null)
            {
                return null;
            }

            if (!options.IsValid())
            {
                WriteErrorMessage("Переданные парамерты невалидны.");
                return null;
            }

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDictionary, Dictionary>();
            serviceCollection.AddSingleton<ISpellChecker, SpellChecker>();
            serviceCollection.AddSingleton<IArgumentManager>(provider => new ArgumentManager(options));
            serviceCollection.AddSingleton<IEditor, Editor>();
            serviceCollection.AddSingleton<FileWriter>();
            serviceCollection.AddSingleton<IInputReader, FileInputReader>();
            serviceCollection.AddSingleton<IOutputWriter>(provider =>
            {
                if (string.IsNullOrWhiteSpace(options.Output))
                {
                    return new ConsoleWriter();
                }
                return provider.GetService<FileWriter>();
            });
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        /// <summary>
        /// Argument parsing and validation method. 
        /// </summary>
        /// <param name="args">Console parameters.</param>
        /// <returns><see cref="Options"/> model or null.</returns>
        private static Options GetOptions(string[] args)
        {
            if (!Parser.TryParse(args, out Options options, new ParserOptions()
            {
                LogParseErrorToConsole = false
            }))
            {
                Parser.DisplayHelp<Options>(HelpFormat.Full);
                return null;
            }

            return options;
        }
        
        /// <summary>
        /// Method printing error message to the console.
        /// </summary>
        /// <param name="errorMessage">Message.</param>
        private static void WriteErrorMessage(string errorMessage)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error. {errorMessage}");
            Console.ForegroundColor = defaultColor;
        }
    }
}