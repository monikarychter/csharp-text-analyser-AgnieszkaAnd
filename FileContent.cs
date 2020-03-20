using System;
using System.IO;

namespace TextAnalyzer {
    class FileContent : IterableText {
        private string fileName;
        private string fileContentText = null;

        public FileContent(String filename) {
            this.fileName = filename;
            string text = File.ReadAllText(filename);
            if (text.Contains("\r\n")) {
                this.fileContentText = File.ReadAllText(filename).Replace("\r\n", " ").Replace("  ", " ").Replace("  ", " ");
            } else {
                this.fileContentText = File.ReadAllText(filename).Replace("\n", " ").Replace("  ", " ").Replace("  ", " ");
            }
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
        public string GetFileChars() {
            return this.fileContentText.ToLower().Replace(" ", string.Empty);
        }
        public string[] GetFileWords() {
            return this.fileContentText.ToLower().Split(" ");
        }
    }
}