class Word {
    private string _word;
    private bool _isHidden;

    public Word(string word){
        _word = word;
        _isHidden = false;
    }

    public void Hide(){
        _isHidden = true;
    }

    public bool IsHidden() {
        return _isHidden;
    }

    public string Display(){
        return _isHidden ? new string('-', _word.Length) : _word;
        }

}