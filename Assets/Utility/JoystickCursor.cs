using UnityEngine;
using System.Runtime.InteropServices;

public class JoystickCursor : MonoBehaviour
{
    [SerializeField] private float speed;
    
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out POINT lpPoint);

    private void Update()
    {
        POINT lpPoint;
        if (!GetCursorPos(out lpPoint)) return;
        var cursorPos = (Vector2) lpPoint;
        
        var x = Input.GetAxis("ControllerCursorHorizontal");
        var y = Input.GetAxis("ControllerCursorVertical");
        cursorPos += new Vector2(x, y) * speed * Time.deltaTime;
        
        SetCursorPos(Mathf.RoundToInt(cursorPos.x), Mathf.RoundToInt(cursorPos.y));

        if (Input.GetButtonDown("ControllerSubmit") && ButtonManager.Instance.CurrentButton != null)
        {
            ButtonManager.Instance.CurrentButton.onClick.Invoke();
        }
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;

    public static implicit operator Vector2(POINT point)
    {
        return new Vector2(point.X, point.Y);
    }
}