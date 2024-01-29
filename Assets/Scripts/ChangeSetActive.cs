using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSetActive : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject UseSword;
    public GameObject Boss;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("MainPlayer"))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_2"))
            {
                     Boss.SetActive(true);
            }
            else
            {
                gameObject1.SetActive(false);
                gameObject2.SetActive(true);
                UseSword.SetActive(true);
                Destroy(gameObject);

            }
            
        }
        
    }

    
}
