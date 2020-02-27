using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    abstract class View {
        public void Print(String stringToBePrinted) {}
        public void Print(List<String> listOfStringsToBePrinted) {}
        public void Print(Dictionary<string, Integer> dictionaryToBePrinted) {}

    }
}