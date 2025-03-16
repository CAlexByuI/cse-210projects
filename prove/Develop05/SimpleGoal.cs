public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            SetIsCompleted(true);
            return Points;
        }
        return 0;
    }

    public override string ToSaveString()
    {
        return $"SimpleGoal|{Name}|{Points}|{IsCompleted}";
    }

    public static Goal FromSaveString(string saveString)
    {
        string[] parts = saveString.Split('|');
        if (parts[0] == "SimpleGoal")
        {
            string name = parts[1];
            int points = int.Parse(parts[2]);
            bool isCompleted = bool.Parse(parts[3]);
            SimpleGoal goal = new SimpleGoal(name, points);
            goal.SetIsCompleted(isCompleted);
            return goal;
        }
        return null;
    }
}
