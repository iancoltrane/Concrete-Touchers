using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int index)
    {
        Application.LoadLevel(index);
    }
}