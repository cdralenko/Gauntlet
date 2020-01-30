using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_arrow : MonoBehaviour
{

    GameObject obj;
    GameObject gc;
    private int state;
    public float arrowspeed;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        gc = GameObject.FindGameObjectWithTag("GameController");
        state = obj.GetComponent<scr_player_controller>().direction;

        if (state == 0) {transform.localEulerAngles = new Vector3(0, 0, 0);}
        if (state == 1) {transform.localEulerAngles = new Vector3(0, 0, 45);}
        if (state == 2) {transform.localEulerAngles = new Vector3(0, 0, 90);}
        if (state == 3) {transform.localEulerAngles = new Vector3(0, 0, 135);}
        if (state == 4) {transform.localEulerAngles = new Vector3(0, 0, 180);}
        if (state == 5) {transform.localEulerAngles = new Vector3(0, 0, 225);}
        if (state == 6) {transform.localEulerAngles = new Vector3(0, 0, 270);}
        if (state == 7) {transform.localEulerAngles = new Vector3(0, 0, 315);}
    }

    private void Update()
    {
        if (gc.GetComponent<scr_game_controller>().pause == false)
        {
            //Up
            if (state == 0) { transform.position = transform.position + new Vector3(0, arrowspeed, 0); }
            //Up Left
            if (state == 1) { transform.position = transform.position + new Vector3(-arrowspeed, arrowspeed, 0); }
            //Left
            if (state == 2) { transform.position = transform.position - new Vector3(arrowspeed, 0, 0); }
            //Down Left
            if (state == 3) { transform.position = transform.position + new Vector3(-arrowspeed, -arrowspeed, 0); }
            //Down
            if (state == 4) { transform.position = transform.position - new Vector3(0, arrowspeed, 0); }
            //Down Right
            if (state == 5) { transform.position = transform.position + new Vector3(arrowspeed, -arrowspeed, 0); }
            //Right
            if (state == 6) { transform.position = transform.position + new Vector3(arrowspeed, 0, 0); }
            //Up Right
            if (state == 7) { transform.position = transform.position + new Vector3(arrowspeed, arrowspeed, 0); }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "walls")
            {Destroy(gameObject); }

        if (other.tag == "enemy")
        {
            other.GetComponent<Enemy>().health--;
            Destroy(gameObject);
        }

        if (other.tag == "spawner")
        {
            other.GetComponent<spawner>().health--;
            Destroy(gameObject);
        }
    }
}
