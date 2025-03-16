public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent() => Points;

    public override string ToSaveString()
    {
        return $"EternalGoal|{Name}|{Points}|{IsCompleted}";
    }

    public static Goal FromSaveString(string saveString)
    {
        string[] parts = saveString.Split('|');
        if (parts[0] == "EternalGoal")
        {
            string name = parts[1];
            int points = int.Parse(parts[2]);
            bool isCompleted = bool.Parse(parts[3]);
            EternalGoal goal = new EternalGoal(name, points);
            goal.SetIsCompleted(isCompleted);
            return goal;
        }
        return null;
    }

    public override string ToString() => $"{Name} (Eternal)";
}
