using System;

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running){
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please Select an Option:");
            Console.WriteLine("1.) add an entry");
            Console.WriteLine("2.) display all entries");
            Console.WriteLine("3.) save entries to file");
            Console.WriteLine("4.) exit the program");
            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    journal.AddUserAnswers();
                    break; 
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
}