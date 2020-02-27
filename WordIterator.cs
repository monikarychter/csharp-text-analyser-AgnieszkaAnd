using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    abstract class WordIterator : Iterator {Char
        public WordIterator(FileContent) {
            // constructor
        }
        public bool HasNext() {
            return false;
        }
        public string MoveNext() {
            return "";
        }
        public void Remove() {}
    }
}