using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    abstract class CharIterator : Iterator {
        private int index;
        private FileContent fileContent; 
        public CharIterator(FileContent fileContent) {
            this.fileContent = fileContent;
            if (fileContent != null) this.index = 0;
            else this.index = -1;
        }
        public bool HasNext() {
            // if (this.index < fileContent)
            return false;
        }
        public string MoveNext() {
            if (this.HasNext()) return fileContent.CharIterator()
            return "";
        }
        public void Remove() {}
    }
}
/*successively iterates over alphabetic characters (single letters) of the text.
It skips all other characters (like white-spaces). Implements MoveNext() and HasNext()
from **Iterator ** interface. NOTE: Chars are represented as Strings
for the sake of simplicity. Remember that characters’ case (UPPER or lower)
should be consistent in our analysis.*/
