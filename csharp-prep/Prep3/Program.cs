using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("Please pick a number: ");
        // magicNumber = int.Parse(Console.ReadLine());
        string keepPlaying = "yes";
        while (keepPlaying == "yes")
        {    
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 51);

        int guess = -1;
        
            while (guess != magicNumber)
            {
                Console.Write("Guess the magic number:");
                guess = int.Parse(Console.ReadLine());
            
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Congrats, you guessed the number!");
                }
            }
            Console.Write("would you like to keep playing? Type yes or no: ");
            keepPlaying = Console.ReadLine();
        }    
    }
}