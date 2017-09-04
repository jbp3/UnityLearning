using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class projectile : MonoBehaviour {

    public GameObject bulletPrefab;
    private Rigidbody2D Rb;
    private float timer = 0;
    private float timerMax = 0;
    private List<GameObject> objs;

    void Start(){}

    void Update()
    { 
        if (!Waited(2)) return;

        //GameObject last = objs.FirstOrDefault();
        //objs.Remove(last);
        //Destroy(last);

        GameObject Clone;
        Clone = (Instantiate(bulletPrefab, transform.position, transform.rotation)) as GameObject;
        Rb = GetComponent<Rigidbody2D>();
        var _v2 = new Vector2(Random.Range(-500f, 500f), 800f);
        Clone.GetComponent<Rigidbody2D>().AddForce(_v2, 0);
        //objs.Add(Clone);
       
    }


    private bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            timer = 0;
            return true;
        }

        return false;
    }

}
