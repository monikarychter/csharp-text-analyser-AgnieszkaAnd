using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    interface Iterator {
        string FirstItem { get;}
        string CurrentItem{ get;}

        public bool HasNext(); // Is Done
        public string MoveNext(); // Next Item
        public void Remove();

    }
}