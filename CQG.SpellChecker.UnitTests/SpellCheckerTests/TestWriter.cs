using System.Collections.Generic;
using CQG.SpellChecker.Interfaces;

namespace CQG.SpellChecker.UnitTests.SpellCheckerTests
{
    public class TestWriter : IOutputWriter
    {
        public List<string> Output { get; set; }

        public TestWriter()
        {
            Output = new List<string>();
        }
        
        public void Dispose()
        {
        }

        public void WriteLine(string line)
        {
            Output.Add(line);
        }
    }
}