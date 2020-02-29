using System;
using System.Collections.Generic;
using System.IO;

namespace TextAnalyzer {
    class FileContent {
        private List<string> _fileContent = null;
        public FileContent(String text) { // what is the difference between String and string?
            this._fileContent = new List<string>();
        }
        public Iterator CharIterator() {
            return new CharIterator(this);
        }
        public Iterator WordIterator() {
            return new WordIterator(this);
        }
        public string GetFilename() {
            //foreach file in the directory - go through and compare content/first line
            // string filename = fi.Name; 
            return "";
        }

        public string this[int itemIndex] {
            get {
                if (itemIndex < _fileContent.Count) {
                    return _fileContent[itemIndex];
                }
                else {
                    return string.Empty;
                }
            }
            set {                
                _fileContent.Add(value);                                
            }
        }
        public int Count {
            get {
                return _fileContent.Count;
            }
        }
    }
}