using System;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject PlayerPrefab { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(this);
    }

    public void SetPrefab(GameObject prefab)
    {
        PlayerPrefab = prefab;
    }
}