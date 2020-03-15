using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer {
    class StatisticalAnalysis {
        public Iterator iterator;
        private Dictionary<string, int> iteratorDictionaryWithCounts= new Dictionary<string, int>();

        public StatisticalAnalysis(Iterator iteratorInstance){
            this.iterator = iteratorInstance;
        }

        public Dictionary<string, int> CountOf(params string[] args) {
            Dictionary<string, int> occurences = new Dictionary<string, int>();
            // Add all args as keys to dictionary
            foreach (string argument in args) {
                occurences.Add(argument, 0);
            }
            // Count occurences of all args in the iterator
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                if (occurences.ContainsKey(this.iterator.CurrentItem)) {
                    occurences[this.iterator.CurrentItem]++;
                }
            }
            return occurences;
        }

        public int DictionarySize() {
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                if (iteratorDictionaryWithCounts.ContainsKey(this.iterator.CurrentItem)) {
                    iteratorDictionaryWithCounts[this.iterator.CurrentItem]++;
                } else {
                    iteratorDictionaryWithCounts[this.iterator.CurrentItem] = 1;
                }
            }
            return iteratorDictionaryWithCounts.Count;
        }

        public int Size() {
            int size = 0;
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                size++;
            }
            return size;
        }

        public List<string> GetMostUsedWords(int limitPercentage) {
            List<string> mostUsedWordsAbovePercentage = new List<string>();
            int wordCountTotal = this.Size();

            if (iteratorDictionaryWithCounts.Count == 0) { DictionarySize(); }
            var items = from pair in iteratorDictionaryWithCounts
                        orderby pair.Value descending
                        select pair;
            double currentPercentage = 0;

            foreach (var pair in items) {
                currentPercentage = (double) 100 * pair.Value/wordCountTotal;
                if (currentPercentage >= limitPercentage) {
                    mostUsedWordsAbovePercentage.Add(pair.Key);
                } else { break; }
            }

            mostUsedWordsAbovePercentage.Sort();
            return mostUsedWordsAbovePercentage;
        }

        public Dictionary<string, double> GetLettersPercentages() {
            if (iteratorDictionaryWithCounts.Count == 0) { DictionarySize(); }

            Dictionary<string, double> results = new Dictionary<string, double>();
            int wordCountTotal = this.Size();
            double currentPercentage;

            foreach (KeyValuePair<string, int> pair in iteratorDictionaryWithCounts) {
                currentPercentage = (double) 100 * pair.Value/wordCountTotal;
                results[pair.Key] = currentPercentage;
            }
            return results;
        }

        public int CountVowels() {
            Dictionary<string, int> counts = this.CountOf("a", "e", "i", "o", "u");// "y" - is not a vowel in Engilsh
            int charCountTotal = this.Size();
            int vowelsCount = 0;

            foreach (int number in counts.Values) { vowelsCount += number; }

            int vowelsPercentage = 100 * vowelsCount/charCountTotal;
            return vowelsPercentage;
        }

        public double CountRatio(string a, string b) {
            Dictionary<string, int> counts = this.CountOf(a, b);
            double ratio = (double) counts[a]/counts[b];
            return ratio;
        }
    }
}