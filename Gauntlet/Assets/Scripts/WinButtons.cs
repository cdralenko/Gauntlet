using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtons : MonoBehaviour
{
    public void ClickMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FinalQuit()
    {
        Application.Quit();
    }
}
