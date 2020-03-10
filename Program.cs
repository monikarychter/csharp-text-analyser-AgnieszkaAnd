using System;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- text1.txt text2.txt
            if (args.Length == 0) {
                System.Console.WriteLine("Please enter at least one commandline argument.");
            }
            
            foreach (string arg in args) {
                FileContent currentFile = new FileContent(arg);

                Iterator charIterForFile = currentFile.CharIterator();
                Iterator wordIterForFile = currentFile.WordIterator();

                // int counter_a = 0;
                // count occurences of a letter in the iterator
                // for (string s = charIterForFile.FirstItem; charIterForFile.HasNext(); s = charIterForFile.MoveNext()) {
                // for (string s = wordIterForFile.FirstItem; wordIterForFile.HasNext(); s = wordIterForFile.MoveNext()) {
                    // System.Console.WriteLine(s);
                    // if (s == "a") {
                    //     counter_a += 1;
                    // } else {
                    //     // info - there is no such a word/letter in the text
                    // }
                // }
                // System.Console.WriteLine($"Counter: {counter_a}");
                StatisticalAnalysis newAnalysisChar = new StatisticalAnalysis(charIterForFile);
                StatisticalAnalysis newAnalysisWord = new StatisticalAnalysis(wordIterForFile);


                int[] countingCharacters = newAnalysisChar.CountOf("a");
                foreach(int item in countingCharacters) {
                    System.Console.WriteLine(item);
                }

                
                int[] countingCharacters2 = newAnalysisChar.CountOf("e");
                foreach(int item in countingCharacters2) {
                    System.Console.WriteLine(item);
                }
                double aToE = (double) countingCharacters[0]/countingCharacters2[0];
                string doubleToPrint = String.Format("{0:0.00}", aToE); 
                System.Console.WriteLine($"a/e ratio is: {doubleToPrint}");

                int[] countingWords = newAnalysisWord.CountOf("music");
                foreach(int item in countingWords) {
                    System.Console.WriteLine(item);
                }
            }

        }
    }
}
