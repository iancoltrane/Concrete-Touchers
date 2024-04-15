using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    public Button CurrentButton;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}