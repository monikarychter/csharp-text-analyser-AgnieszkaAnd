using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    interface Iterator {
        public bool HasNext();
        public string MoveNext();
        public void Remove();
    }
}