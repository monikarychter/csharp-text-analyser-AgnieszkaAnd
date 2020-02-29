using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    class WordIterator : Iterator {
        private int index = 0;
        private FileContent fileContent = null; 
        public WordIterator(FileContent fileContent) {
            this.fileContent = fileContent;
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
}