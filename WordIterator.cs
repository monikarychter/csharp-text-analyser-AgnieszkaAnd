using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    class WordIterator : Iterator {
        private int index = 0;
        private List<string> data = new List<string>();
        public string FirstItem {
            get {
                index = 0;
                return data[index];
            }
        }
        public string CurrentItem {
            get {
                return data[index];
            }
        }

        public WordIterator(FileContent fileContent) {
            string temp = fileContent.GetFileText().Replace("\r", " ");
            foreach (string word in temp.ToLower().Split(" ")){
                data.Add(word.ToString());
            }
        }
        public bool HasNext() {
            if (index < data.Count) {
                return true;
            }
            return false;
        }
        public string MoveNext() {
            index += 1;
            if (HasNext()) {
                return data[index];
            } else {
                return string.Empty;
            }
        }
        public void Remove() {}

    }
}