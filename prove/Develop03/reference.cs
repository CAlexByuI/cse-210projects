class Reference 
{
    private string _book; // Stores the book name (e.g., "John")
    private int _chapter; // Stores the chapter number
    private int _startingVerse; // Stores the starting verse number
    private int? _endingVerse; // Stores the ending verse (nullable for single-verse references)

    // Constructor to initialize a reference with book, chapter, and verse(s)
    public Reference(string book, int chapter, string versePart) 
    {
        _book = book;
        _chapter = chapter;

        // Check if the verse contains a range (e.g., "3-5") or a single verse (e.g., "16")
        string[] verseParts = versePart.Split('-'); // Splits on "-", e.g., "3-5" -> ["3", "5"]
        _startingVerse = int.Parse(verseParts[0]); // Always set the first part as the starting verse

        // If a range is provided, parse the ending verse; otherwise, set it to null
        if (verseParts.Length > 1) 
        {
            _endingVerse = int.Parse(verseParts[1]);
        } 
        else 
        {
            _endingVerse = null; // No range, meaning it's a single-verse reference
        }
    }

    // Returns the formatted reference string (e.g., "John 3:16" or "John 3:16-18")
    public string GetReference() 
    {
        if (_endingVerse.HasValue) 
        {
            return $"{_book} {_chapter}:{_startingVerse}-{_endingVerse}"; // Multi-verse format
        } 
        else 
        {
            return $"{_book} {_chapter}:{_startingVerse}"; // Single-verse format
        }
    }
}
