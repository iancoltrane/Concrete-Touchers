using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private int updateAmount = 10;
    
    public void UpdateScore()
    {
        ScoreManager.Instance.AddScore(updateAmount);
    }
}