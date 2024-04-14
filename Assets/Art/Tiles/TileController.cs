using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class TileController : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        foreach (var material in _renderer.materials)
        {
            material.mainTextureScale = transform.localScale;
        }
    }
}
