using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    interface IterableText {
        public Iterator CharIterator();
        public Iterator WordIterator();
    }
}