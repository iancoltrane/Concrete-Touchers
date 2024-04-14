using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CameraController : MonoBehaviour, ITransformUpdateable
{
    [SerializeField, Range(0f, 1f)] private float smoothAmount = .15f;
    [SerializeField] private Vector3 offset = Vector3.right;
    [SerializeField] private Transform target;

    private Vector3 _velocity = Vector3.zero;
    
    private void FixedUpdate()
    {
        // This will move the camera towards the target position smoothly,
        // it is easier on the eyes and typically "best practice" from a game design perspective.
        // Feel free to play with the smoothAmount in the editor or revert the code entirely.
        
        var targetPos = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothAmount);
    }

    public void UpdateTransform(Transform t)
    {
        target = t;
    }
}
