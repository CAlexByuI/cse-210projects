public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int requiredCount, int bonusPoints)
        : base(name, points)
    {
        _requiredCount = requiredCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public int CurrentCount { get => _currentCount; }
    public int RequiredCount { get => _requiredCount; }
    public int BonusPoints { get => _bonusPoints; }

    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            _currentCount++;
            if (_currentCount >= _requiredCount)
            {
                SetIsCompleted(true);
                return Points + _bonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string ToSaveString()
    {
        return $"ChecklistGoal|{Name}|{Points}|{IsCompleted}|{_requiredCount}|{_currentCount}|{_bonusPoints}";
    }

    public static Goal FromSaveString(string saveString)
    {
        string[] parts = saveString.Split('|');
        if (parts[0] == "ChecklistGoal")
        {
            string name = parts[1];
            int points = int.Parse(parts[2]);
            bool isCompleted = bool.Parse(parts[3]);
            int requiredCount = int.Parse(parts[4]);
            int currentCount = int.Parse(parts[5]);
            int bonusPoints = int.Parse(parts[6]);

            ChecklistGoal goal = new ChecklistGoal(name, points, requiredCount, bonusPoints);
            goal.SetIsCompleted(isCompleted);
            goal.SetCurrentCount(currentCount);
            return goal;
        }
        return null;
    }
    public override string ToString()
{
    return $"{Name} - {CurrentCount}/{RequiredCount} tasks completed";
}
}
