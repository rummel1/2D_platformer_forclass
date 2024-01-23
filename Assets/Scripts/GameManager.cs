using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject Player;
    private Rigidbody2D rb;
    private Vector2 playerCheckpointPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RespawnPlayer();
        }
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
        Player.transform.position = playerCheckpointPosition;
        rb.velocity = Vector2.zero;
    }
}