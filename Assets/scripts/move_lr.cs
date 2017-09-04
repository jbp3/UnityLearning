using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_lr : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public float distance;
    private float start;
    private float end;
    private bool toggleDirection;
    

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        end = transform.position.x + distance;
        start = transform.position.x;
        toggleDirection = false;
        
    }

	void Update () {

        if (!toggleDirection)
        {
            if (transform.position.x < (start + distance))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
                toggleDirection = true;
            }        
        }


        if (toggleDirection)
        {
            if (rb.position.x > (start - distance))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
                toggleDirection = false;
            }
        }

    }
}
