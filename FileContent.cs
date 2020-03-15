using System;
using System.IO;

namespace TextAnalyzer {
    class FileContent {
        private string fileName;
        private string fileContentText = null;
        public FileContent(String filename) {
            this.fileName = filename;
            this.fileContentText = File.ReadAllText(filename).Replace("\n", " ");
        }
        public Iterator CharIterator() {
            return new CharIterator(this);
        }
        public Iterator WordIterator() {
            return new WordIterator(this);
        }
        public string GetFilename() {
            return this.fileName;
        }
        public string GetFileText() {
            return this.fileContentText;
        }
    }
}