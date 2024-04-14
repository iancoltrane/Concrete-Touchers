using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] private List<GameObject> transformUpdateables;
    [SerializeField] private Transform loadingTransform;
    
    private void Start()
    {
        if (PlayerManager.Instance == null || PlayerManager.Instance.PlayerPrefab == null) return;

        var player = Instantiate(PlayerManager.Instance.PlayerPrefab, loadingTransform.position, Quaternion.identity);
        foreach (var transformUpdateable in transformUpdateables)
        {
            var updateable = transformUpdateable.GetComponent<ITransformUpdateable>();
            if (updateable == null) continue;

            updateable.UpdateTransform(((GameObject) player).transform);
        }
    }
}