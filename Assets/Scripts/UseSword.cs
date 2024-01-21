using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSword : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject infoCanvas;
    public GameObject barCanvas;

    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        foreach (Transform child in _inventory.slots[0].transform)
        {
            Destroy(child.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        infoCanvas.SetActive(true);
        barCanvas.SetActive(true);
    }

    public void exitbutton()
    {
        infoCanvas.SetActive(false);
    }
}
