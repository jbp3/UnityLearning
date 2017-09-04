using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_manager : MonoBehaviour {

    public float respawn_delay;
    public player_controller game_player;
    public int points;
    public int health;
    public Text score_output;

    // Use this for initialization
    void Start()
    {
        game_player = FindObjectOfType<player_controller>();
        score_output.text = string.Format("Score: {0}", points);
        health = 100;
        score_output.text = string.Format("Score: {0} - Health: {1}", points, health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Respawn();
        
    }
    public void Respawn()
    {
        StartCoroutine("_Respawn");
    }

    public IEnumerator _Respawn()
    {
        game_player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawn_delay);
        game_player.transform.position = game_player.RespawnPoint;
        game_player.gameObject.SetActive(true);
        health = 100;
        points = 0;
        score_output.text = string.Format("Score: {0} - Health: {1}", points, health);
    }

    public void Addpoints(int count)
    {
        points += count;
        score_output.text = string.Format("Score: {0} Health: {1}", points, health);
    }

    public void AddHealth(int count)
    {
        health += count;
        score_output.text = string.Format("Score: {0} Health: {1}", points, health);
    }

    public void RemoveHealth(int count)
    {
        health = health - count;
        score_output.text = string.Format("Score: {0} Health: {1}", points, health);
    }
}
