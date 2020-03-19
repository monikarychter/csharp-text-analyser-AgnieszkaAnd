using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAnalyzer {
    class CharIterator : Iterator {
        private int index;
        private FileContent data;
        private string fileChars;

        public string FirstItem {
            get { index = 0; return fileChars[index].ToString(); }
        }
        public string CurrentItem {
            get { return fileChars[this.index].ToString(); }
        }

        public CharIterator(FileContent fileContent) {
            this.index = 0;
            this.data = fileContent;
            this.fileChars = fileContent.GetFileChars();
        }

        public bool HasNext() {
            if (this.index < fileChars.Length) {
                return true;
            }
            return false;
        }
        
        public string MoveNext() {
            this.index++;
            if (HasNext()) {
                return fileChars[this.index].ToString();
            } else {
                return string.Empty;
            }
        }
        public void Remove() {}
        
        public static bool isAlphaNumeric(string strToCheck) {
            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(strToCheck);
        }
    }
}