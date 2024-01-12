using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    private Inventory _inventory;
    public int i;
  
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            _inventory.isFull[i] = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Transform child in _inventory.slots[0].transform)
            {
                Destroy(child.gameObject);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Transform child in _inventory.slots[1].transform)
            {
                Destroy(child.gameObject);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (Transform child in _inventory.slots[2].transform)
            {
                Destroy(child.gameObject);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (Transform child in _inventory.slots[3].transform)
            {
                Destroy(child.gameObject);
            }
           
        }
    }
}
