public class Prompt
{
    public string _question { get; set; }
    public string _answer { get; set; }

    public Prompt(string question)
    {
        _question = question;
        _answer = string.Empty;
    }
}