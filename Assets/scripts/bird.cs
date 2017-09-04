using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public int direction;
    public Transform obj;

    void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (direction == 1)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (obj.position.x < -60)
            {
                obj.position = new Vector2(60, obj.position.y);
                rb.velocity = Vector2.zero;
            }
        }
        else if (direction == 2)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (obj.position.x > 60)
            {
                obj.position = new Vector2(-60, obj.position.y);
                rb.velocity = Vector2.zero;
            }
        }  
    }
}
