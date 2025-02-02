using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    public DateTime _date { get; set; }
    public List<Prompt> _prompts { get; set; }
    private PromptGenerator _promptGenerator;
    public Journal()
    {
        _date = DateTime.Now;
        _prompts = new List<Prompt>();
        _promptGenerator = new PromptGenerator();


    }

    public void  SaveToFile()
    {
        string fileName = $"journal_{_date.ToString("yyyy-MM-dd")}.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {
            outputFile.WriteLine();
            foreach (var prompt in _prompts)
            {
                outputFile.WriteLine($"{prompt._question}");
                outputFile.WriteLine($"{prompt._answer}");
            }
            outputFile.WriteLine();
        }
    }
    public void AddUserAnswers()
    {
        Prompt newPrompt = new Prompt(_promptGenerator.GetRandomPrompt());
        Console.WriteLine(newPrompt._question);
        newPrompt._answer = Console.ReadLine();
        _prompts.Add(newPrompt);
    }

    public void DisplayEntries()
    {
        if (_prompts.Count == 0)
        {
            Console.WriteLine("There are no journal entries to display yet.");
            return;
        }

        foreach (var prompt in _prompts)
        {
            Console.WriteLine($"Q: {prompt._question}");
            Console.WriteLine($"A: {prompt._answer}\n");
        }
    }
}

