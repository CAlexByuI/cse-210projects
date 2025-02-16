class Reference {
    private string _book;
    private int _chapter;
    private int _startingVerse;
    private int? _endingVerse;

    public Reference(string book, int chapter, string versePart) {
        _book = book;
        _chapter = chapter;

        string[] verseParts = versePart.Split('-');
        _startingVerse = int.Parse(verseParts[0]);

        if (verseParts.Length > 1) {
            _endingVerse = int.Parse(verseParts[1]);
        } else {
            _endingVerse = null; 
        }
    }

    public string GetReference() {
        if (_endingVerse.HasValue) {
            return $"{_book} {_chapter}:{_startingVerse}-{_endingVerse}";
        } else {
            return $"{_book} {_chapter}:{_startingVerse}";
        }
    }
}
