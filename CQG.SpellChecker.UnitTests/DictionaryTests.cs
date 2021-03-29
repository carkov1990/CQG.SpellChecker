using NUnit.Framework;
using Shouldly;

namespace CQG.SpellChecker.UnitTests
{
    [TestFixture]
    public class DictionaryTests
    {
        private Dictionary _dictionary;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dictionary = new Dictionary();
        }

        [Test]
        public void Dictionary_Fill_Contains_Success()
        {
            //Arrange
            var words = new string[] {"one", "two", "three", "four", "five"};
            //Act
            _dictionary.FillDictionary(words);
            //Assert
            foreach (var word in words)
            {
                _dictionary.ContainsWord(word).ShouldBeTrue();
            }
        }
        
        [Test]
        public void Dictionary_Fill_Contains_Failed()
        {
            //Arrange
            var words = new string[] {"one", "two", "three", "four", "five"};
            //Act
            _dictionary.FillDictionary(words);
            //Assert
            foreach (var word in words)
            {
                _dictionary.ContainsWord(word + " ").ShouldBeFalse();
            }
        }
        
        [Test]
        public void Dictionary_Fill_ValuesByWord()
        {
            //Arrange
            var words = new string[] {"aa", "bbb", "cccc", "ddddd","eeeeee", "fffffff", "gggggggg"};
            _dictionary.FillDictionary(words);
            //Act
            var dictionaryWords = _dictionary.GetDictionaryValuesByWord("dddd1");
            //Assert
            dictionaryWords.ShouldNotContain("aa");
            dictionaryWords.ShouldNotContain("gggggggg");
        }
    }
}