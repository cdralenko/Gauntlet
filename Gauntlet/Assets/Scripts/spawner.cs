using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public int spawndelay;
    public GameObject enemy;
    public Vector3 spawnplace;
    public int health;
    GameObject gc;

    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = spawndelay;
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.GetComponent<scr_game_controller>().pause == false)
        {
                counter--;

                if (counter == 0)
                {
                    Instantiate(enemy, spawnplace, Quaternion.identity);
                    counter = spawndelay;
                }

                if (health == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
