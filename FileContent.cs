using System;
using System.Collections.Generic;
using System.IO;

namespace TextAnalyzer {
    class FileContent {
        private string _fileName;
        private string _fileContentText = null;
        public FileContent(String filename) {
            this._fileName = filename;
            this._fileContentText = File.ReadAllText(filename).Replace("\n", " ");
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
    }
}