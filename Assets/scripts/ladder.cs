using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

    private bool OnLadder = false;
    private Rigidbody2D player;

    void Start () {}
	
	void Update ()
    {
        if (OnLadder)
        {
            if (Input.GetAxis("Vertical") > 0)
            {

                player.velocity = new Vector2(player.velocity.x, 5f);

            }
        }
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponentInParent<Rigidbody2D>();
            OnLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnLadder = false;
        }
    }
}
