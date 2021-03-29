using System;
using System.Collections.Generic;
using System.Linq;
using CQG.SpellChecker.Interfaces;
using CQG.SpellChecker.Utils;

namespace CQG.SpellChecker
{
    /// <summary>
    /// Класс редактора.
    /// </summary>
    public class Editor : IEditor
    {
        /// <inheritdoc cref="IEditor.Edit"/>
        public string Edit(string word, string[] dictionaryWords)
        {
            var singlePrescriptionList = new List<string>();
            var doublePrescriptionList = new List<string>();
            foreach (var dictionaryWord in dictionaryWords)
            {
                var prescription = LevenshteinDistance.Calculate(word, dictionaryWord);
                if (prescription.Distance == 1)
                {
                    singlePrescriptionList.Add(dictionaryWord);
                }
                else if (prescription.Distance == 2 & !prescription.Route.Contains("DD") &&
                         !prescription.Route.Contains("II"))
                {
                    doublePrescriptionList.Add(dictionaryWord);
                }
            }

            var resultCollection = singlePrescriptionList.Count > 0 ? singlePrescriptionList : doublePrescriptionList;
            

            if (resultCollection.Count > 0)
            {
                if (resultCollection.Count == 1)
                {
                    return resultCollection.First();
                }
                else
                {
                    return $"{{{String.Join(' ', resultCollection)}}}";
                }
            }
            return $"{{{word}?}}";
        }
    }
}