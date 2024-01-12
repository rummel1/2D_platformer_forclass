using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject potion;
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.isFull[i] == false)
                {
                    Instantiate(potion, _inventory.slots[i].transform, false);
                    _inventory.isFull[i] = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
