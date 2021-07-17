using UnityEngine.Events;

public static class Score
{
    public static int Value { get; private set; }

    public static UnityAction ScoreUpdated;

    public static void Add(int value)
    {
        if (Value + value > 0)
        {
            Value += value;

            ScoreUpdated?.Invoke();
        }
    }

    public static void Reset()
    {
        Value = 0;
    }
}
