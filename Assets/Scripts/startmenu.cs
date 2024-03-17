using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("CHARACTER SELECT");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MENU");
    }

    public void Character2()
    {
        SceneManager.LoadScene("CHARACTER 2");
    }

    public void Character3()
    {
        SceneManager.LoadScene("CHARACTER 3");
    }

    public void Character4()
    {
        SceneManager.LoadScene("CHARACTER 4");
    }

    public void Character5()
    {
        SceneManager.LoadScene("CHARACTER 5");
    }

    public void Character6()
    {
        SceneManager.LoadScene("CHARACTER 6");
    }

    public void Character1()
    {
        SceneManager.LoadScene("CHARACTER 1");
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}