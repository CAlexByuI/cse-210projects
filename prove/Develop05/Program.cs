using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager("goals.txt");
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nGoal Tracker - Total Points: {manager.TotalPoints}");
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        manager.ListGoals();
                        break;
                    case 2:
                        AddGoal(manager);
                        break;
                    case 3:
                        RecordEvent(manager);
                        break;
                    case 4:
                        manager.Save();
                        break;
                    case 5:
                        manager.Load();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddGoal(Manager manager)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Checklist Goal");
        Console.WriteLine("3. Eternal Goal");

        if (int.TryParse(Console.ReadLine(), out int goalType))
        {
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter points: ");
            if (int.TryParse(Console.ReadLine(), out int points))
            {
                switch (goalType)
                {
                    case 1:
                        manager.CreateGoal(new SimpleGoal(name, points));
                        break;
                    case 2:
                        AddChecklistGoal(manager, name, points);
                        break;
                    case 3:
                        manager.CreateGoal(new EternalGoal(name, points));
                        break;
                    default:
                        Console.WriteLine("Invalid goal type. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input for points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for goal type.");
        }
    }

    static void AddChecklistGoal(Manager manager, string name, int points)
    {
        Console.Write("Enter required count: ");
        if (int.TryParse(Console.ReadLine(), out int requiredCount))
        {
            Console.Write("Enter bonus points: ");
            if (int.TryParse(Console.ReadLine(), out int bonusPoints))
            {
                manager.CreateGoal(new ChecklistGoal(name, points, requiredCount, bonusPoints));
            }
            else
            {
                Console.WriteLine("Invalid input for bonus points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for required count.");
        }
    }

    static void RecordEvent(Manager manager)
    {
        manager.ListGoals();
        Console.Write("Choose a goal to record an event: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            manager.RecordEvent(goalIndex - 1);  // Fixed off-by-one error
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}