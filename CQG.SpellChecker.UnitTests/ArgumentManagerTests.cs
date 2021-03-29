using System;
using CQG.SpellChecker.Models;
using NUnit.Framework;
using Shouldly;

namespace CQG.SpellChecker.UnitTests
{
    [TestFixture]
    public class ArgumentManagerTests
    {
        private string _inputPath = "input";
        private string _outputPath = "output";
        private ArgumentManager _argumentManager;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _argumentManager = new ArgumentManager(new Options()
            {
                Input = _inputPath,
                Output = _outputPath
            });
        }

        [Test]
        public void Constructor_NullOptions_Throw()
        {
            Should.Throw<ArgumentNullException>(() =>
            {
                var argumentManager = new ArgumentManager(null);
            });
        }
        
        [Test]
        public void GetInputArgument_ShouldBe_InputPath()
        {
            _argumentManager.GetInputArgument().ShouldBe(_inputPath);
        }
        
        [Test]
        public void GetOutputArgument_ShouldBe_OutputPath()
        {
            _argumentManager.GetOutputArgument().ShouldBe(_outputPath);
        }
    }
}