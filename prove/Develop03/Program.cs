using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = LoadScripturesFromFile("..\\..\\..\\scriptures.txt");

        if (scriptures.Count == 0) {
            Console.WriteLine("No scriptures found in file.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        Console.WriteLine(scripture.DisplayScripture());

        while (true) 
        {
            Console.WriteLine("\nEnter the number of words to hide (or type 'exit' to quit):");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit") break;

            if (int.TryParse(input, out int wordsToHide) && wordsToHide > 0)
            {
                scripture.HideWords(wordsToHide);
                Console.Clear();
                Console.WriteLine(scripture.DisplayScripture());

                if (scripture.AllWordsHidden()) 
                {
                    Console.WriteLine("\nAll words are hidden! Press ENTER to exit.");
                    Console.ReadLine();
                    break;
                }
            }
            else 
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filename) 
    {
        List<Scripture> scriptures = new List<Scripture>();

        try {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines) 
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(": ", 2);
                if (parts.Length < 2) continue;

                string reference = parts[0];
                string verseText = parts[1];

                scriptures.Add(new Scripture(reference, verseText));
            }
        } 
        catch (Exception ex) 
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        return scriptures;
    }
}
