using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSetActive : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            gameObject1.SetActive(false);
            gameObject2.SetActive(true);
            Destroy(gameObject);
        }
        
    }

    
}
