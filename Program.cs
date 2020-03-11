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
                FileContent currentFile = new FileContent(arg);

                // DEBUG PART:
                // string filereadtxt =  File.ReadAllText("test.txt");
                // string filereadtxt2 =  File.ReadAllText("test2.txt");

                Iterator charIterForFile = currentFile.CharIterator();
                Iterator wordIterForFile = currentFile.WordIterator();

                // DEBUG PART:
                // int counter_a = 0;
                // count occurences of a letter in the iterator
                // for (string s = charIterForFile.FirstItem; charIterForFile.HasNext(); s = charIterForFile.MoveNext()) {
                // for (string s = charIterForFile.FirstItem; charIterForFile.HasNext(); s = charIterForFile.MoveNext()) {
                // for (string s = wordIterForFile.FirstItem; wordIterForFile.HasNext(); s = wordIterForFile.MoveNext()) {
                //     System.Console.WriteLine(s);
                    // System.Console.WriteLine(s);
                    // if (s == "a") {
                    //     counter_a += 1;
                    // } else {
                    //     // info - there is no such a word/letter in the text
                    // }
                // }


                StatisticalAnalysis newAnalysisChar = new StatisticalAnalysis(charIterForFile);
                StatisticalAnalysis newAnalysisWord = new StatisticalAnalysis(wordIterForFile);

                System.Console.WriteLine($"=={currentFile.GetFilename()}==");
                System.Console.WriteLine($"Char count: {newAnalysisChar.Size()}");
                System.Console.WriteLine($"Word count: {newAnalysisWord.Size()}");
                System.Console.WriteLine($"Dict size: {newAnalysisWord.DictionarySize()}");
                System.Console.Write($"Most used words (>1%): [");
                foreach (string item in newAnalysisWord.GetMostUsedWords(1)) {
                    System.Console.Write($"{item},");
                }
                System.Console.WriteLine("]");
                System.Console.WriteLine($"'love' count: {newAnalysisWord.CountOf("love")[0]}");
                System.Console.WriteLine($"'hate' count: {newAnalysisWord.CountOf("hate")[0]}");
                System.Console.WriteLine($"'music' count: {newAnalysisWord.CountOf("music")[0]}");
                System.Console.WriteLine($"vowels %: {newAnalysisChar.CountVowels()}");
                System.Console.WriteLine($"'a' count: {newAnalysisChar.CountOf("a")[0]}");
                System.Console.WriteLine($"'e' count: {newAnalysisChar.CountOf("e")[0]}");
                System.Console.WriteLine($"'a:e count ratio' : {String.Format("{0:0.00}", newAnalysisChar.CountRatio("a","e"))}");
                
                // foreach (Dictionary<string, double> item in newAnalysisChar.LetterPercentage()) {
                //     System.Console.Write($"[ {item.Key.ToUpper()} -> {item.Value}");
                // }
            }
        }
    }
}
