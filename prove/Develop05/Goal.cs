public abstract class Goal
{
    public string Name { get; }
    public int Points { get; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordEvent();
    public abstract string ToSaveString();
    public static Goal FromSaveString(string saveString)
{
    string[] parts = saveString.Split('|');
    switch (parts[0])
    {
        case "SimpleGoal":
            return SimpleGoal.FromSaveString(saveString);
        case "EternalGoal":
            return EternalGoal.FromSaveString(saveString);
        case "ChecklistGoal":
            return ChecklistGoal.FromSaveString(saveString);
        default:
            Console.WriteLine("Unknown goal type encountered.");
            return null;
    }
}

    protected void SetIsCompleted(bool value)
    {
        IsCompleted = value;
    }
}
