using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomit_birds : MonoBehaviour {
    public GameObject bulletPrefab;
    private Rigidbody2D Rb;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject Clone;
        Clone = (Instantiate(bulletPrefab, transform.position, transform.rotation)) as GameObject;
        Rb = GetComponent<Rigidbody2D>();
        var _v2 = new Vector2(800f, 0);
        Clone.GetComponent<Rigidbody2D>().AddForce(_v2, 0);
        //_Destroy(20f, Clone);
    }
}
