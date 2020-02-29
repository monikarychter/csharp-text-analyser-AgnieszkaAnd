using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    interface Iterator {
        public bool HasNext(); // Is Done
        public string MoveNext(); // Next Item
        public void Remove();

        string FirstItem { get;}
        string CurrentItem{ get;}
    }
}