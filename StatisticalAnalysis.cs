using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    class StatisticalAnalysis {
        public Iterator iterator;

        public StatisticalAnalysis(Iterator iteratorName){
            this.iterator = iteratorName;
        }

        public int[] CountOf(params string[] args) {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            // Add all keys from args to dictionary
            foreach (string argument in args) {
                counts.Add(argument, 0);
            }
            // Iterator iterator1 = this.iterator;
            for (string s = this.iterator.FirstItem; this.iterator.HasNext(); s = this.iterator.MoveNext()) {
                if (counts.ContainsKey(this.iterator.CurrentItem)) {
                    counts[this.iterator.CurrentItem] += 1;
                } else {
                    // info - there is no such a word/letter in the text
                }
            }
            // while (this.iterator.HasNext()){
                // if (counts.ContainsKey(this.iterator.CurrentItem)) {
                //     counts[this.iterator.CurrentItem] += 1;
                // } else {
                //     // info - there is no such a word/letter in the text
                // }
            //     this.iterator.MoveNext();
            // }
            int[] results = new int[args.Length];
            int indexCountOf = 0;
            foreach (string argument in args) { //???
                // return counts[argument];
                results[indexCountOf] = counts[argument];
                indexCountOf++;
            }
            return results;
            
        //     for (string s = iter.FirstItem; iter.IsDone == false;  s = iter.NextItem )
        // {
        //     Console.WriteLine(s);
        // }
        }

        public int DictionarySize() {
            return -1;
        }

        public int Size() {
            return -1;
        }

        // public ISet<string> OccurMoreThan(Integer number) {
        //     return ISet;
        // }
    }
}