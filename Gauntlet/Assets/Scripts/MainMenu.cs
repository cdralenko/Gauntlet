using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        SceneManager.UnloadSceneAsync("WinScreen");
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gauntlet");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
