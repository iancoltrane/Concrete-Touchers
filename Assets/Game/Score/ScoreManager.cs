using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private IntegerDisplay display;
    
    private int _score;

    public void AddScore(int amount)
    {
        _score += amount;
        display.DisplayInteger(_score);
    }
}