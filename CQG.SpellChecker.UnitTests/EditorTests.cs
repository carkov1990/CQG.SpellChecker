using CQG.SpellChecker.Interfaces;
using Microsoft.Win32;
using NUnit.Framework;
using Shouldly;

namespace CQG.SpellChecker.UnitTests
{
    [TestFixture]
    public class EditorTests
    {
        private IEditor _editor;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _editor = new Editor();
        }

        [TestCase("low", "flow big small", "flow")]
        [TestCase("lower", "flowers low", "flowers")]
        [TestCase("team", "steams stream meat", "{steams stream}")]
        [TestCase("ower", "flower bear", "{ower?}")]
        [TestCase("flower", "ower bear", "{flower?}")]
        [TestCase("industry", "indtry isindustry", "{industry?}")]
        [TestCase("industry", "industr ndustry", "{industr ndustry}")]
        public void Editor_Edit(string word, string dictionary, string expectedResult)
        {
            //Arrange
            //Act
            var result = _editor.Edit(word, dictionary.Split(' '));
            
            //Assert
            result.ShouldBe(expectedResult);
        }
    }
}