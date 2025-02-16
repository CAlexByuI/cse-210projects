class Word 
{
    private string _word;   // Stores the actual word
    private bool _isHidden; // Indicates whether the word is hidden

    // Constructor to initialize the word and set its hidden status to false
    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    // Method to hide the word by setting _isHidden to true
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to check if the word is hidden
    public bool IsHidden() 
    {
        return _isHidden;
    }

    // Method to display the word; if hidden, returns dashes of the same length
    public string Display()
    {
        return _isHidden ? new string('-', _word.Length) : _word;
    }
}
