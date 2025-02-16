using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Load scriptures from the text file
        List<Scripture> scriptures = LoadScripturesFromFile("..\\..\\..\\scriptures.txt");

        // Check if any scriptures were loaded
        if (scriptures.Count == 0) {
            Console.WriteLine("No scriptures found in file.");
            return; // Exit if no scriptures are available
        }

        // Select a random scripture from the list
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        // Display the selected scripture
        Console.WriteLine(scripture.DisplayScripture());

        // Main loop for hiding words based on user input
        while (true) 
        {
            Console.WriteLine("\nEnter the number of words to hide (or type 'exit' to quit):");
            string input = Console.ReadLine();

            // Allow user to exit the program
            if (input.ToLower() == "exit") break;

            // Validate input and ensure it's a positive integer
            if (int.TryParse(input, out int wordsToHide) && wordsToHide > 0)
            {
                // Hide the specified number of words
                scripture.HideWords(wordsToHide);
                Console.Clear(); // Clear the console for a cleaner display
                Console.WriteLine(scripture.DisplayScripture());

                // Check if all words have been hidden
                if (scripture.AllWordsHidden()) 
                {
                    Console.WriteLine("\nAll words are hidden! Press ENTER to exit.");
                    Console.ReadLine(); // Wait for user input before exiting
                    break;
                }
            }
            else 
            {
                // Handle invalid input
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }
    }

    // Method to load scriptures from a file
    static List<Scripture> LoadScripturesFromFile(string filename) 
    {
        List<Scripture> scriptures = new List<Scripture>();

        try {
            // Read all lines from the specified file
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines) 
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Split each line into reference and verse text
                string[] parts = line.Split(": ", 2);
                if (parts.Length < 2) continue; // Ensure the line is correctly formatted

                string reference = parts[0]; // Extract the scripture reference
                string verseText = parts[1]; // Extract the verse text

                // Create a Scripture object and add it to the list
                scriptures.Add(new Scripture(reference, verseText));
            }
        } 
        catch (Exception ex) 
        {
            // Handle file reading errors
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return scriptures; // Return the list of loaded scriptures
    }
}
