using UnityEngine;

public class PlayerPrefabSetter : MonoBehaviour
{
    public void SetPrefab(GameObject prefab)
    {
        if (PlayerManager.Instance == null) return;

        PlayerManager.Instance.SetPrefab(prefab);
    }
}