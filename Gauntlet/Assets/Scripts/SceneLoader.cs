using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool exitLevel;

    private void Start()
    {
        exitLevel = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Gauntlet_Lvl2");
            exitLevel = true;
        }
    }

    private void Update()
    {
        if (exitLevel)
        {
            SceneManager.UnloadSceneAsync("Gauntlet");
        }
    }
}
