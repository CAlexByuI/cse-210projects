using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = 0;
        do{
        Console.WriteLine("Please enter a list of numbers, type 0 when finished: ");
        number = int.Parse(Console.ReadLine());
        numbers.Add(number);
    
        } while (number != 0);

        Console.WriteLine("The sum ofthe numbers is " + numbers.Sum());
        Console.WriteLine("The Average of all the numbers is " + numbers.Average());
        Console.WriteLine("The largest number in the list is " + numbers.Max());
        numbers.Sort();
        Console.WriteLine("The list in sorted order is: " + string.Join(", ", numbers));
    }
}