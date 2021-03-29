using System.Collections.Generic;
using System.Linq;
using CQG.SpellChecker.Interfaces;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс работы со словарем.
    /// </summary>
    public class Dictionary : IDictionary
    {
        private HashSet<string> _hash;
        private List<string>[] _buckets;

        /// <summary>
        /// .ctor
        /// </summary>
        public Dictionary()
        {
            _hash = new HashSet<string>();
            _buckets = new List<string>[0];
        }
        
        /// <inheritdoc cref="IDictionary.FillDictionary"/>
        public void FillDictionary(string[] words)
        {
            if (words.Length > 0)
            {
                _hash = words.ToHashSet();
                _buckets = new List<string>[words.Max(x=>x.Length + 1)];
                _buckets = _buckets.Select(x => new List<string>()).ToArray();
                foreach (var word in words)
                {
                    _buckets[word.Length].Add(word);                
                }
            }
        }

        /// <inheritdoc cref="IDictionary.ContainsWord"/>
        public bool ContainsWord(string word)
        {
            return _hash.Contains(word);
        }

        /// <inheritdoc cref="IDictionary.GetDictionaryValuesByWord"/>
        public string[] GetDictionaryValuesByWord(string word)
        {
            var fromIndex = word.Length < 1 || word.Length - 2 > _buckets.Length ? 0 : word.Length - 2;
            var toIndex = word.Length + 3 > _buckets.Length ? _buckets.Length : word.Length + 3;
            var dictionaryWords = _buckets[fromIndex..toIndex].SelectMany(x=>x).ToArray();
            return dictionaryWords;
        }
    }
}