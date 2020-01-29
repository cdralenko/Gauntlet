using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_controller : MonoBehaviour
{

    public float playerspeed;
    public GameObject arrow;
    GameObject obj;

    // Direction numbers are 0-7 going counter clockwise
    public int direction; 

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Direction Code
        #region
        //Movement code cardinal directions (NSEW)
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            transform.position = transform.position + new Vector3(0, playerspeed, 0);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            direction = 0;
        }

        if ((Input.GetKey(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            transform.position = transform.position - new Vector3(0, playerspeed, 0);
            transform.localEulerAngles = new Vector3(0, 0, 180);
            direction = 4;
        }

        if ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.position = transform.position - new Vector3(playerspeed, 0, 0);
            transform.localEulerAngles = new Vector3(0, 0, 90);
            direction = 2;

        }

        if ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.position = transform.position + new Vector3 (playerspeed, 0, 0);
            transform.localEulerAngles = new Vector3(0, 0, 270);
            direction = 6;
        }

        //Movement code secondary directions (NW NE SW SE)
        if (((Input.GetKey(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow))))
        {
            transform.localEulerAngles = new Vector3(0, 0, 45);
            direction = 1;
        }

        if (((Input.GetKey(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow))))
        {
            transform.localEulerAngles = new Vector3(0, 0, 315);
            direction = 7;
        }

        if (((Input.GetKey(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))) && ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow))))
        {
            transform.localEulerAngles = new Vector3(0, 0, 135);
            direction = 3;
        }

        if (((Input.GetKey(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))) && ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow))))
        {
            transform.localEulerAngles = new Vector3(0, 0, 225);
            direction = 5;
        }
        #endregion //direction code

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "key")
        {
            obj.GetComponent<scr_game_controller>().key++;
            Destroy(other.gameObject);
        }

        if (other.tag == "door")
        {
            if ((obj.GetComponent<scr_game_controller>().key) > 0)
            {
                obj.GetComponent<scr_game_controller>().key--;
                Destroy(other.gameObject);
            }
        }
    }
}
