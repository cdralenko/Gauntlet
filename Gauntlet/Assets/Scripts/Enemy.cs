using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private GameObject playerobject;
    private Transform player;
    public int health;
    GameObject gc;

    // Start is called before the first frame update
    void Start()
    {
        playerobject = GameObject.Find("Player");
        gc = GameObject.FindGameObjectWithTag("GameController");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.GetComponent<scr_game_controller>().pause == false)
        {
                player = playerobject.GetComponent<Transform>();


                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                direction.Normalize();
                movement = direction;

                if (health == 0)
                {
                gc.GetComponent<scr_game_controller>().score += 10;
                    Destroy(gameObject);
                }

                if (gc.GetComponent<scr_game_controller>().win == true)
                {
                Destroy(gameObject);
                }
        }
    }

    private void FixedUpdate()
    {
        if (gc.GetComponent<scr_game_controller>().pause == false)
        {
                moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
