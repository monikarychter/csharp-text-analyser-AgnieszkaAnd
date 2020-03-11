using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzer {
    class StatisticalAnalysis {
        public Iterator iterator;
        Dictionary<string, int> dict= new Dictionary<string, int>();

        public StatisticalAnalysis(Iterator iteratorName){
            this.iterator = iteratorName;
        }

        public int[] CountOf(params string[] args) {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            // Add all keys from args to dictionary
            foreach (string argument in args) {
                counts.Add(argument, 0);
            }
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                if (counts.ContainsKey(this.iterator.CurrentItem)) {
                    counts[this.iterator.CurrentItem] += 1;
                } else {
                    // info - there is no such a word/letter in the text
                }
            }
            int[] results = new int[args.Length];
            int indexCountOf = 0;
            foreach (string argument in args) {
                results[indexCountOf] = counts[argument];
                indexCountOf++;
            }
            return results;
        }

        public int DictionarySize() {
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                if (dict.ContainsKey(this.iterator.CurrentItem)) {
                    dict[this.iterator.CurrentItem] += 1;
                } else {
                    dict[this.iterator.CurrentItem] = 1;
                }
            }
            return dict.Count;
        }


        public int Size() {
            int size = 0;
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                size++;
            }
            return size;
        }

        public List<string> GetMostUsedWords(int percentage) {
            List<string> results = new List<string>();
            int wordCountTotal = this.Size();
            var items = from pair in dict
                    orderby pair.Value descending
                    select pair;
                    
            double currentPercentage = 0;

            foreach (KeyValuePair<string, int> pair in items) {
                currentPercentage = (double) 100 * pair.Value/wordCountTotal;
                results.Add(pair.Key);
                if (currentPercentage < percentage) { break; }
            }
            results.Sort();
            return results;
        }

        public int CountVowels() {
            int[] counts = this.CountOf("a", "e", "i", "o", "u");//, "y");
            int vowelsCount = 0;
            foreach (int number in counts) {
                vowelsCount += number;
            }            
            int charCountTotal = this.Size();
            int vowelsPercentage = 100 * vowelsCount/charCountTotal;
            return vowelsPercentage;
        }

        public double CountRatio(string a, string b) {
            int[] counts = this.CountOf(a, b);
            double ratio = (double) counts[0]/counts[1];
            return ratio;
        }

        public Dictionary<string, double> LetterPercentage() {
            Dictionary<string, double> percentages = new Dictionary<string, double>();
            int charCountTotal = this.Size();

            foreach (string letter in dict.Keys) {
                if (percentages.Keys.Contains(letter)){
                    percentages[letter] += 1;
                } else {
                    percentages[letter] = 1;
                }
            }
            foreach (string letter in dict.Keys) {
                percentages[letter] = (double) 100*percentages[letter]/charCountTotal;
            }
            return percentages;
        }
    }
}