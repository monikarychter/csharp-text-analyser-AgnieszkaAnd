using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    class CharIterator : Iterator {
        private int index = 0;
        private FileContent fileContent = null; 
        public CharIterator(FileContent fileContent) {
            this.fileContent = fileContent;
            // if (fileContent != null) this.index = 0;
            // else this.index = -1;
        }
        public bool HasNext() {
            if (index < fileContent.Count) {
                return true;
            }
            return false;
        }
        public string MoveNext() {
            index += 1;
            if (HasNext()) {
                return fileContent[index];
            } else {
                return string.Empty;
            }
        }
        public void Remove() {}
        public string FirstItem {
            get {
                index = 0;
                return fileContent[index];
            }
        }
        public string CurrentItem {
            get {
                return fileContent[index];
            }
        }
    }
}
/*successively iterates over alphabetic characters (single letters) of the text.
It skips all other characters (like white-spaces). Implements MoveNext() and HasNext()
from **Iterator ** interface. NOTE: Chars are represented as Strings
for the sake of simplicity. Remember that characters’ case (UPPER or lower)
should be consistent in our analysis.*/
