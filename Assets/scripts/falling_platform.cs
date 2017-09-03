using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform : MonoBehaviour {


    Rigidbody2D Rb;
    Collider2D C;
	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody2D>();
        C = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fall()
    {
        StartCoroutine("_Fall");
    }

    public IEnumerator _Fall()
    {
        yield return new WaitForSeconds(0.25f);
        //Rb.transform.Translate(Vector3.down * 30f * Time.deltaTime, Space.World);
        //Rb.transform.Rotate(Vector3.forward, 30f * Time.deltaTime);
        Rb.constraints = RigidbodyConstraints2D.None;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bridge")
        {
            //Physics.IgnoreCollision2D(transform.collider2D, other);
            Physics2D.IgnoreCollision(other, C);
        }

        if (other.tag == "Player")
        {
            Fall();
        }
    }
}
