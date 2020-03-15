using System;
using System.Collections.Generic;

namespace TextAnalyzer {
    abstract class View {
        public static void Print(String title, double value) {
            System.Console.WriteLine($"{title}: {value}");
        }
        public static void Print(String title, List<String> listOfStrings) {
            System.Console.Write($"{title}: ");
            System.Console.Write("[");
            string stringToPrint = "";
            foreach (string item in listOfStrings) {
                stringToPrint += item + ",";
            }
            System.Console.Write(stringToPrint.Trim(','));
            System.Console.WriteLine("]");
        }
        public static void Print(Dictionary<string, double> dictionaryToBePrinted) {
            foreach (KeyValuePair<string, double> item in dictionaryToBePrinted) {
                System.Console.Write($"[ {item.Key.ToUpper()} -> {String.Format("{0:0.00}", item.Value)}] ");
            }
        }

    }
}