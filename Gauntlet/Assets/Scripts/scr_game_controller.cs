using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        key = 0;
        health = totalhealth;
        score = 0;

        endtext.text = "";
        scoretext.text = "";
        healthtext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + score;
        healthtext.text = "Health: " + health;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause) { pause = true; }
            else { pause = false; }
            
        }

        if (health == 0)
        {
            endtext.text = "You Failed, Scrub";
        }
    }
}
