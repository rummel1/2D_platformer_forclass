using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryManager : MonoBehaviour
{
    

    private int number = 0;
    private bool isProcessActive = false;

    void Start()
    {
        InvokeRepeating("UpdateNumber", 0f, 5f);
    }

    void UpdateNumber()
    {
        for (int i = 1; i < 6; i++)
        {
            if (!isProcessActive)
            {
                isProcessActive = true;
                StartCoroutine(UpdateNumberCoroutine());
            }
        }
    }

    IEnumerator UpdateNumberCoroutine()
    {
        int targetValue = 100;

        while (number != targetValue)
        {
            number += (targetValue > number) ? 5 : -20;
            Debug.Log("Number: " + number);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(5f);

        isProcessActive = false;
    }

    
    
}

    



