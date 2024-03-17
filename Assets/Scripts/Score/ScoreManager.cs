using TMPro;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _score;

    public UnityEvent<int> OnScoreUpdated = new();

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreUpdated.Invoke(_score);
    }
}