using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_player_controller : MonoBehaviour
{

    public float playerspeed;
    public GameObject arrow;
    GameObject obj;
    bool vulnerable;
    bool shootpause;
    Renderer rend;
    Color c;

    private SpriteRenderer sr;

    public Sprite leftsprite;
    public Sprite rightsprite;
    public Sprite upsprite;
    public Sprite downsprite;


    // Direction numbers are 0-7 going counter clockwise
    public int direction; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        obj = GameObject.FindGameObjectWithTag("GameController");
        vulnerable = true;
        shootpause = false;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //allows for the pausing system to work by freezing any updates that the player would make
        if ((obj.GetComponent<scr_game_controller>().pause == false) || (obj.GetComponent<scr_game_controller>().win == true))
        {
            if (shootpause == false)
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
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    direction = 4;
                }

                if ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.position = transform.position - new Vector3(playerspeed, 0, 0);
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    direction = 2;

                }

                if ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.position = transform.position + new Vector3(playerspeed, 0, 0);
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    direction = 6;
                }

                //Movement code secondary directions (NW NE SW SE)
                //up left
                if (((Input.GetKey(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow))))
                {
                    transform.localEulerAngles = new Vector3(0, 0, 45);
                    direction = 1;
                }

                //up right
                if (((Input.GetKey(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow))))
                {
                    transform.localEulerAngles = new Vector3(0, 0, 315);
                    direction = 7;
                }
                //down left
                if (((Input.GetKey(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))) && ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow))))
                {
                    transform.localEulerAngles = new Vector3(0, 0, 315);
                    direction = 3;
                }

                //down right
                if (((Input.GetKey(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))) && ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow))))
                {
                    transform.localEulerAngles = new Vector3(0, 0, 45);
                    direction = 5;
                }
                #endregion //direction code
            }

            if ((direction == 0) || (direction == 1) || (direction == 7)) {sr.sprite = upsprite;}
            if ((direction == 4) || (direction == 3) || (direction == 5)) {sr.sprite = downsprite;}
            if (direction == 6) {sr.sprite = rightsprite;}
            if (direction == 2) {sr.sprite = leftsprite;}

            //shoots a projectile. Also starts coroutine that briefly stops the player
            if (Input.GetKeyDown(KeyCode.Space))
            {
               Instantiate(arrow, transform.position, Quaternion.identity);
               StartCoroutine("shoot");
            }
            
            //Death. Effect can be adjusted later.
            if (obj.GetComponent<scr_game_controller>().health == 0)
            {
                obj.GetComponent<scr_game_controller>().pause = true;
            }
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

        if (other.tag == "enemy")
        {
            if ((vulnerable == true) && (obj.GetComponent<scr_game_controller>().health > 0))
            {
                obj.GetComponent<scr_game_controller>().health--;
                if (obj.GetComponent<scr_game_controller>().health > 1)
                {
                    StartCoroutine("Invulnerable");
                }
            }
        }

        if (other.tag == "gold")
        {
            Destroy(other.gameObject);
            obj.GetComponent<scr_game_controller>().score += 50;
            
        }

        if (other.tag == "health")
        {
            Destroy(other.gameObject);
            obj.GetComponent<scr_game_controller>().totalhealth += 1;
            obj.GetComponent<scr_game_controller>().health = obj.GetComponent<scr_game_controller>().totalhealth;
            
        }

        if (other.tag == "finish")
        {
            SceneManager.LoadScene("Gauntlet_Lvl2");
        }

        if (other.tag == "finish2")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    //creates invincibility frames for the player when being hit, with minor graphics to add to it
    IEnumerator Invulnerable()
    {
        vulnerable = false;
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(1.5f);
        c.a = 1f;
        rend.material.color = c;
        vulnerable = true;
    }

    //causes the player to stop in place for a moment when shooting
    IEnumerator shoot()
    {
        shootpause = true;
        yield return new WaitForSeconds(.35f);
        shootpause = false;
    }
}
