using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companion : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public float WalkSpeed;
    public level_manager LevelManager;
    private Animator Anim;
    private Rigidbody2D Rb;
    private SpriteRenderer Sr;
    public Vector3 RespawnPoint;
    public float Jump_height;

    [SerializeField]
   // private float range = 10.0f;
    public float distance;


    // Use this for initialization
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        RespawnPoint = transform.position;
        LevelManager = FindObjectOfType<level_manager>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(0, dir.x) * Mathf.Rad2Deg;

        //&& IsGrounded == true
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("_jump");

        } 

        distance = Distance();
        if (distance < 4)
        {
            return;
        }

        if (distance > 5)
        {
            if (angle == 0)
            {

                transform.localScale = new Vector2(1f, 1f);
            }
            else
            {

                transform.localScale = new Vector2(-1f, 1f);
            }

            Vector2 velocity = new Vector2((transform.position.x - (player.transform.position.x) - 4) * WalkSpeed, (transform.position.y - player.transform.position.y) * WalkSpeed);
            Vector2 xero = new Vector2();
            GetComponent<Rigidbody2D>().velocity = xero;
            GetComponent<Rigidbody2D>().velocity = -velocity;
        }


        Anim.SetFloat("Speed", Mathf.Abs(Rb.velocity.x));
        Anim.SetBool("OnGround", transform.localScale.y <= 1);


    }

    public IEnumerator _jump()
    {
        yield return new WaitForSeconds(0.25f);
        Rb.velocity = new Vector2(Rb.velocity.x, Jump_height);
    }


    private float Distance()
    {
        return Vector3.Distance(transform.position, player.transform.position);
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
    }



}