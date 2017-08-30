using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

    public float Walk_speed;
    public float Run_speed;
    public float Jump_height;
    private Animator Anim;
    private Rigidbody2D Rb;
    private SpriteRenderer Sr;
    public Vector3 RespawnPoint;
    public level_manager LevelManager;
    public Transform GroundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    private bool IsGrounded;
    public int health;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        RespawnPoint = transform.position;
        LevelManager = FindObjectOfType<level_manager>();
        health = 100;
    }

    void Update()
    {
        //checks if any object on ground layer is within radius of ground check game object attached to players feet.
         IsGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, GroundLayer);
        //player can only jump when grounded 

        if (Input.GetKey(KeyCode.Space))
        {
            if(IsGrounded)
            Rb.velocity = new Vector2(Rb.velocity.x, Jump_height);

            //if (transform.position.x < -1)
            //    Rb.velocity = new Vector2(Rb.velocity.x, Jump_height);
        }
       

     

        if (Input.GetKey(KeyCode.D))
        {
            Rb.velocity = new Vector2(Walk_speed, Rb.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rb.velocity = new Vector2(-Walk_speed, Rb.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }

        Anim.SetFloat("Speed", Mathf.Abs(Rb.velocity.x));
        Anim.SetBool("OnGround", transform.localScale.y <= 1);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "lower")
        {
            LevelManager.Respawn();
        }

        if (other.tag == "checkpoint")
        {
            RespawnPoint = other.transform.position;
        }

        //if (other.tag == "enemy")
        //{
        //    LevelManager.RemoveHealth(5);
        //}

        //if (other.tag == "power_up")
        //{
        //    LevelManager.AddHealth(5);
        //}
    }
}
