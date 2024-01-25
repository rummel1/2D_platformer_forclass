using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject Player;
    private Rigidbody2D rb;
    private Vector2 playerCheckpointPosition;
    
    public Animator animator;
    

    private void Update()
    {
    }

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("MainPlayer");
        rb = Player.GetComponent<Rigidbody2D>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpointPosition(Vector2 position)
    {
        playerCheckpointPosition = position;
    }

    public void RespawnPlayer()
    {
        animator.SetBool("Death",false);
        Player.transform.position = playerCheckpointPosition;
        rb.velocity = Vector2.zero;
        Player_health.currentHealth = 100;
        Player.GetComponent<PlayerController>().enabled = true;
    }
}