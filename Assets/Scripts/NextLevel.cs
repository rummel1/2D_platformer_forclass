using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject F;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("MainPlayer"))
        {
            F.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            if (Input.GetKey(KeyCode.F))
            { 
               F.SetActive(false);
               SceneManager.LoadScene("Level_2");
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        F.SetActive(false);
    }
}
