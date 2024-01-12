using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    // Start is called before the first frame update
    public static int maxHealth = 100;
    public static int currentHealth;
    public Animator animator;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        healthBar.SetHealth(currentHealth);
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Damage");
        Debug.Log("player hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       animator.SetBool("Death",true);
       GetComponent<PlayerController>().enabled = false;
    }

    

}
