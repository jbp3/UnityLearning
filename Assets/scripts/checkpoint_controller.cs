using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint_controller : MonoBehaviour {

    public bool checkPointReached;
    public SceneManager SM;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Check point reached!");
            SceneManager.LoadScene("level_two");
        }
            
       // score = score + value;
       // Debug.Log(string.Format("Score : {0}", score));
       // Destroy(gameObject);
    }
}
