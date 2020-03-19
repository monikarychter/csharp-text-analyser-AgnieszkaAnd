using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer {
    class StatisticalAnalysis {
        public Iterator iterator;
        private Dictionary<string, int> iteratorDictionaryWithCounts= new Dictionary<string, int>();
        private Dictionary<string, double> iteratorDictionaryWithPercentages= new Dictionary<string, double>();

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
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext().ToString()) {
                if (occurences.ContainsKey(this.iterator.CurrentItem)) {
                    occurences[this.iterator.CurrentItem]++;
                }
            }
            return occurences;
        }

        public int DictionarySize() {
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext().ToString()) {
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
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext().ToString()) {
                size++;
            }
            return size;
        }

        public List<string> GetMostUsedWords(int limitPercentage) {
            if (iteratorDictionaryWithPercentages.Count == 0) { GetLettersPercentages(); }
            List<string> mostUsedWordsAbovePercentage = new List<string>();
            int wordCountTotal = this.Size();

            foreach (var pair in iteratorDictionaryWithPercentages) {
                if (pair.Value >= (double) limitPercentage) {
                    mostUsedWordsAbovePercentage.Add(pair.Key);
                }
            }

            mostUsedWordsAbovePercentage.Sort();
            return mostUsedWordsAbovePercentage;
        }

        public Dictionary<string, double> GetLettersPercentages() {
            if (iteratorDictionaryWithCounts.Count == 0) { DictionarySize(); }

            int wordCountTotal = this.Size();
            double currentPercentage;

            foreach (KeyValuePair<string, int> pair in iteratorDictionaryWithCounts) {
                currentPercentage = (double) 100 * pair.Value/wordCountTotal;
                iteratorDictionaryWithPercentages[pair.Key] = currentPercentage;
            }
            return iteratorDictionaryWithPercentages;
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
            return Math.Round(ratio, 2);
        }
    }
}