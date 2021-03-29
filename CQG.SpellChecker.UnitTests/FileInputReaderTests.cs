using System.Linq;
using CQG.SpellChecker.Models;
using NUnit.Framework;
using Shouldly;

namespace CQG.SpellChecker.UnitTests
{
    [TestFixture]
    public class FileInputReaderTests
    {
        private string[] _dictionaryWords =
            "rain spain plain plaint pain main mainly the in on fall falls his was".Split(' ');

        private string[] _text = new[] {"hte rame in pain fells", "mainy oon teh lain", "was hints pliant"};

        private FileInputReader _inputReader;

        [OneTimeSetUp]
        public void SetUp()
        {
            _inputReader = new FileInputReader(new ArgumentManager(new Options()
            {
                Input = "input.txt"
            }));
        }

        [Test]
        public void FileInputReader_ReadDictionary()
        {
            //Arrange
            //Act
            var dictionaryWords = _inputReader.GetDictionaryWords();
            //Assert
            dictionaryWords.Length.ShouldBe(_dictionaryWords.Length);

            var exceptList = dictionaryWords.Except(_dictionaryWords);
            exceptList.Count().ShouldBe(0);
        }

        [Test]
        public void FileInputReader_ReadText()
        {
            //Arrange
            //Act
            var textLines = _inputReader.GetTextLines();
            //Assert
            var lineNumber = 0;
            foreach (var line in textLines)
            {
                line.ShouldBe(_text[lineNumber]);
                lineNumber++;
            }
        }
    }
}