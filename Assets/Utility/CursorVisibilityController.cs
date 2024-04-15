using UnityEngine;

public class CursorVisibilityController : MonoBehaviour
{
    [SerializeField] private bool visible;
    
    private void Start()
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}