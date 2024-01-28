using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Use : MonoBehaviour
{
    private Inventory _inventory;
    public int i;
    [SerializeField] private AudioClip _usePotion;
  
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
        
        if (Input.GetKeyDown(KeyCode.Alpha1)&& Player_health.currentHealth is < 96 and > 0 )
        {
            foreach (Transform child in _inventory.slots[0].transform)
            {
                if (child.CompareTag("Potion"))
                {
                     Destroy(child.gameObject);
                     Player_health.currentHealth += 5;
                     SoundManager.instance.PlaySound(_usePotion);
                }
               
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&Player_health.currentHealth is < 96 and > 0 )
        {
            foreach (Transform child in _inventory.slots[1].transform)
            {
                if (child.CompareTag("Potion"))
                {
                    Destroy(child.gameObject);
                    Player_health.currentHealth += 5;
                    SoundManager.instance.PlaySound(_usePotion);
                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&Player_health.currentHealth is < 96 and > 0 )
        {
            foreach (Transform child in _inventory.slots[2].transform)
            {
                if (child.CompareTag("Potion"))
                {
                    Destroy(child.gameObject);
                    Player_health.currentHealth += 5;
                    SoundManager.instance.PlaySound(_usePotion);
                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&& Player_health.currentHealth is < 96 and > 0 )
        {
            foreach (Transform child in _inventory.slots[3].transform)
            {
                if (child.CompareTag("Potion"))
                {
                    Destroy(child.gameObject);
                    Player_health.currentHealth += 5;
                    SoundManager.instance.PlaySound(_usePotion);
                }
            }
           
        }
    }
}
