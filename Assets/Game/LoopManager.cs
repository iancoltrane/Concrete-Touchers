using UnityEngine;

public class LoopManager : MonoBehaviour, ITransformUpdateable
{
    [SerializeField] private GameObject loopedTerrain;
    [SerializeField] private float loopRange = 100f;

    private Transform _playerTransform;
    private int _loops = 1;
    
    public void UpdateTransform(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        if (_playerTransform.position.x >= loopedTerrain.transform.position.x * (_loops + 1) - loopRange)
        {
            Loop();
        }
    }

    private void Loop()
    {
        var loopedTransform = loopedTerrain.transform;
        Instantiate(loopedTerrain, loopedTransform.position + Vector3.right * loopedTransform.position.x * _loops, 
            loopedTransform.rotation);
        _loops++;
    }
}