using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Score
{
    private static int _value;

    public static int Value => _value;

    public static UnityAction ScoreUpdated;

    public static void Add(int value)
    {
        if (_value + value > 0)
        {
            _value += value;

            ScoreUpdated?.Invoke();
        }
    }

    public static void Reset()
    {
        _value = 0;
    }
}
