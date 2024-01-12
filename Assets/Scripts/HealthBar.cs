using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    } 
    public void SetMaxHealth(int health)
    {
        slider.value = health;
        slider.maxValue = health;
    }
}
