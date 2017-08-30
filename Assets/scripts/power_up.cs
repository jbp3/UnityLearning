using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour {

    private level_manager LevelManager;
    public int value;

    // Use this for initialization
    void Start()
    {
        LevelManager = FindObjectOfType<level_manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

            LevelManager.AddHealth(value);
        }
    }
}
