public class Manager
{
    private List<Goal> _allGoals = new List<Goal>();
    private string _fileName;
    private int _totalPoints = 0;

    public int TotalPoints => _totalPoints;

    public Manager(string fileName)
    {
        _fileName = fileName;
    }

    public void CreateGoal(Goal goal)
    {
        _allGoals.Add(goal);
        Console.WriteLine("Goal added successfully.");
    }

    public void ListGoals()
    {
        if (_allGoals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _allGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_allGoals[i].ToString()}");
        }
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _allGoals.Count)
        {
            int pointsEarned = _allGoals[goalIndex].RecordEvent();
            _totalPoints += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points! Total Points: {_totalPoints}");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void Save()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                writer.WriteLine(_totalPoints);
                foreach (var goal in _allGoals)
                {
                    writer.WriteLine(goal.ToSaveString());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving goals: {e.Message}");
        }
    }

    public void Load()
    {
        if (!File.Exists(_fileName))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        _allGoals.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                if (int.TryParse(reader.ReadLine(), out int savedPoints))
                {
                    _totalPoints = savedPoints;
                }
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Goal goal = Goal.FromSaveString(line);
                    if (goal != null)
                        _allGoals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error loading goals: {e.Message}");
        }
    }
}
