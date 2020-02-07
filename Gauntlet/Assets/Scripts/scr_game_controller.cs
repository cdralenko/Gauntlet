using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_game_controller : MonoBehaviour
{
    public int totalhealth;

    public int key;
    public int health;
    public int score;

    public Text endtext;
    public Text scoretext;
    public Text healthtext;

    public bool pause = false;
    public bool win = false;

    
    void Start()
    {
        key = 0;
        health = totalhealth;
        score = 0;

        endtext.text = "";
        scoretext.text = "";
        healthtext.text = "";
    }
    
    void Update()
    {
        scoretext.text = "SCORE: " + score;
        healthtext.text = "HEALTH: " + health;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause) { pause = true; }
            else { pause = false; }
            
        }

        if (health == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Application.Quit();
        }
    }
}
