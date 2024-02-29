using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void StartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Help()
    {
        SceneManager.LoadScene(2);
    }
    public void Back()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("WinScene");
    }

}
