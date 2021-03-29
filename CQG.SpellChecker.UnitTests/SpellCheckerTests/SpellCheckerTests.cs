using CQG.SpellChecker.Interfaces;
using CQG.SpellChecker.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;

namespace CQG.SpellChecker.UnitTests.SpellCheckerTests
{
    [TestFixture]
    public class SpellCheckerTests
    {
        private string _fileInput = "input.txt";

        private string[] _outputText = new[]
            {"the {rame?} in pain falls", "{main mainly} on the plain", "was {hints?} plaint"};
        
        private ISpellChecker _spellChecker;
        private TestWriter _testWriter;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            var provider = GetServiceProvider();
            _spellChecker = provider.GetService<ISpellChecker>();
            _testWriter = (TestWriter) provider.GetService<IOutputWriter>();
        }
        
        private ServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDictionary, Dictionary>();
            serviceCollection.AddSingleton<ISpellChecker, SpellChecker>();
            serviceCollection.AddSingleton<IArgumentManager>(provider => new ArgumentManager(new Options()
            {
                Input = _fileInput
            }));
            serviceCollection.AddSingleton<IEditor, Editor>();
            serviceCollection.AddSingleton<FileWriter>();
            serviceCollection.AddSingleton<IInputReader, FileInputReader>();
            serviceCollection.AddSingleton<IOutputWriter, TestWriter>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        [Test]
        public void SpellCheker_Check()
        {
            //Arrange
            //Act
            _spellChecker.Check();
            //Assert
            foreach (var outputLine in _testWriter.Output)
            {
                _outputText.ShouldContain(outputLine);
            }
        }
    }
}