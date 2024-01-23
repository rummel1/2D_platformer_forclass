using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform checkpointTransform;

    void Start()
    {
        checkpointTransform = transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            SaveCheckpoint();
        }
    }

    void SaveCheckpoint()
    {
        GameManager.instance.SetCheckpointPosition(checkpointTransform.position);
        Debug.Log("Checkpoint saved!");
    }
}