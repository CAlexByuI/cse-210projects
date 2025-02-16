class Scripture 
{
    private List<Word> _scriptures = new List<Word>(); // List to store words of the scripture
    private Reference _scriptureReference; // Holds the scripture reference (book, chapter, verse)
    private Random _random = new Random(); // Random object for selecting words to hide

    // Constructor to initialize scripture with a reference and verse text
    public Scripture(string reference, string verses) 
    {
        // Split the verse text into individual words and store them as Word objects
        foreach (string word in verses.Split(" ")) 
        {
            _scriptures.Add(new Word(word));
        }

        // Extract the book name and chapter:verse information
        string[] splitReference = reference.Split(" "); // ["John", "3:16"]
        string book = splitReference[0];
        string[] chapterAndVerse = splitReference[1].Split(":"); // ["3", "16"]

        int chapter = int.Parse(chapterAndVerse[0]); // Convert chapter to integer
        string versePart = chapterAndVerse[1]; // Can be a single verse or a range (e.g., "1-4")

        // Create a Reference object for the scripture
        _scriptureReference = new Reference(book, chapter, versePart);
    }

    // Returns the formatted scripture text with the reference
    public string DisplayScripture() 
    {
        string verseText = string.Join(" ", _scriptures.ConvertAll(w => w.Display()));
        return $"{_scriptureReference.GetReference()} - {verseText}";
    }

    // Hides a specified number of words in the scripture
    public void HideWords(int count) 
    {
        List<Word> visibleWords = _scriptures.FindAll(w => !w.IsHidden()); // Get list of visible words
        int wordsToHide = Math.Min(count, visibleWords.Count); // Ensure we don't hide more than available words

        for (int i = 0; i < wordsToHide; i++) 
        {
            int index = _random.Next(visibleWords.Count); // Pick a random index
            visibleWords[index].Hide(); // Hide the selected word
            visibleWords.RemoveAt(index); // Remove it from the visible words list to avoid duplication
        }
    }

    // Checks if all words in the scripture have been hidden
    public bool AllWordsHidden() 
    {
        return _scriptures.TrueForAll(w => w.IsHidden()); // Returns true if all words are hidden
    }
}
