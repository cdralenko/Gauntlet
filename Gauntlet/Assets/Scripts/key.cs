using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Player")
        {
            obj.GetComponent<scr_game_controller>().key++;
            Destroy(gameObject);
        }
    }
}
