using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    // Start is called before the first frame update
    public static int health = 100;
    public Animator animator;

    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Damage");
        Debug.Log("player hit");

        if (health <= 0)
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
