using System;
using System.Collections.Generic;
using System.IO;

namespace TextAnalyzer {
    class FileContent {
        private string _fileName;
        private string _fileContentText = null;
        // private string[] _fileContent = null;
        public FileContent(String filename) { // what is the difference between String and string?
            this._fileName = filename;
            this._fileContentText = File.ReadAllText(filename).Replace("\n", string.Empty);
            // this._fileContent = _fileContentText.Split("");
        }
        public Iterator CharIterator() {
            return new CharIterator(this);
        }
        public Iterator WordIterator() {
            return new WordIterator(this);
        }
        public string GetFilename() {
            return this._fileName;
        }
        public string GetFileText() {
            return this._fileContentText;
        }

        // public string this[int itemIndex] {
        //     get {
        //         if (itemIndex < _fileContent.) {
        //             return _fileContent[itemIndex];
        //         }
        //         else {
        //             return string.Empty;
        //         }
        //     }
        //     set {                
        //         _fileContent.Add(value);                                
        //     }
        // }
        // public int Count {
        //     get {
        //         return _fileContent.Count;
        //     }
        // }
    }
}