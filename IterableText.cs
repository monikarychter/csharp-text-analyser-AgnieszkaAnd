using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    interface IterableText {
        public Iterator CharIterator();
        public Iterator WordIterator();

        string this[int itemIndex]{set;get;}
        int Count{get;}
    }
}