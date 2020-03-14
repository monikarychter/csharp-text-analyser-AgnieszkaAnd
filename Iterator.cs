namespace TextAnalyzer {
    interface Iterator {
        string FirstItem { get; }
        string CurrentItem{ get; }

        bool HasNext();
        string MoveNext();
        void Remove();
    }
}