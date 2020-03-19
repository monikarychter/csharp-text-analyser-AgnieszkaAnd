namespace TextAnalyzer {
    class WordIterator : Iterator {
        private int index;
        private FileContent data;
        private string[] fileWords;
        public string FirstItem {
            get { index = 0; return fileWords[index]; }
        }
        public string CurrentItem {
            get { return fileWords[index]; }
        }

        public WordIterator(FileContent fileContent) {
            this.index = 0;
            this.data = fileContent;
            this.fileWords = fileContent.GetFileWords();
        }

        public bool HasNext() {
            if (index < fileWords.Length) {
                return true;
            }
            return false;
        }

        public string MoveNext() {
            this.index++;
            if (HasNext()) {
                return fileWords[index];
            } else {
                return string.Empty;
            }
        }
        public void Remove() {}

    }
}