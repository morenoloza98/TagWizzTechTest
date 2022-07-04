using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    private static int _score; // current score value

    public static int ScoreVar => _score; // A reference to get the score's value without being able to change it

    public static event Action<int> OnAddScoreEvent; // C# event to invoke when the score is increased

    // Increase score by the given amount
    public static void AddScore(int amount)
    {
        _score += amount;
        OnAddScoreEvent.Invoke(_score); // Call/Invoke OnAddScore event
    }

    // Set score back to zero
    public static void ResetScore()
    {
        _score = 0;
    }
}
