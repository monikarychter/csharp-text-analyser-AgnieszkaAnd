namespace TextAnalyzer {
    interface IterableText {
        Iterator CharIterator();
        Iterator WordIterator();
    }
}