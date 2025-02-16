class Scripture {
    private List<Word> _scriptures = new List<Word>();
    private Reference _scriptureReference;
    private Random _random = new Random();

    public Scripture(string reference, string verses) {
        foreach (string word in verses.Split(" ")) {
            _scriptures.Add(new Word(word));
        }

        string[] splitReference = reference.Split(" ");
        string book = splitReference[0];
        string[] chapterAndVerse = splitReference[1].Split(":");

        int chapter = int.Parse(chapterAndVerse[0]);
        string versePart = chapterAndVerse[1];

        _scriptureReference = new Reference(book, chapter, versePart);
    }

    public string DisplayScripture() {
        string verseText = string.Join(" ", _scriptures.ConvertAll(w => w.Display()));
        return $"{_scriptureReference.GetReference()} - {verseText}";
    }

    public void HideWords(int count) {
        List<Word> visibleWords = _scriptures.FindAll(w => !w.IsHidden());

        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++) {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden() {
        return _scriptures.TrueForAll(w => w.IsHidden());
    }
}
