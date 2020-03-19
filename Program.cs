using System;
using System.IO;

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

                FileContent currentFile = null;

                try { currentFile = new FileContent(arg); }
                catch (FileNotFoundException e) {
                    System.Console.WriteLine(e.GetType().ToString() + " Please input a valid filename.");
                    continue;
                }

                Iterator charIterForFile = currentFile.CharIterator();
                Iterator wordIterForFile = currentFile.WordIterator();

                StatisticalAnalysis newAnalysisChar = new StatisticalAnalysis(charIterForFile);
                StatisticalAnalysis newAnalysisWord = new StatisticalAnalysis(wordIterForFile);

                System.Console.WriteLine($"\n=={currentFile.GetFilename()}==");
                View.Print("Char count", newAnalysisChar.Size());
                View.Print("Word count", newAnalysisWord.Size());
                View.Print("Dict size", newAnalysisWord.DictionarySize());
                View.Print("Most used words (>1%)", newAnalysisWord.GetMostUsedWords(1));
                View.Print("'love' count", newAnalysisWord.CountOf("love")["love"]);
                View.Print("'hate' count", newAnalysisWord.CountOf("hate")["hate"]);
                View.Print("'music' count", newAnalysisWord.CountOf("music")["music"]);
                View.Print("vowels %", newAnalysisChar.CountVowels());
                View.Print("'a' count", newAnalysisChar.CountOf("a")["a"]);
                View.Print("'e' count", newAnalysisChar.CountOf("e")["e"]);
                View.Print("'a:e count ratio'",  newAnalysisChar.CountRatio("a","e"));
                View.Print(newAnalysisChar.GetLettersPercentages());
            }
        }
    }
}
