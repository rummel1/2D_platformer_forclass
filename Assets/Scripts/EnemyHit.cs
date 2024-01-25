using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    private int _currentHealth;
    [SerializeField] private AudioClip _enemyHit;
    void Start()
    {
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        SoundManager.instance.PlaySound(_enemyHit);
        animator.SetTrigger("Hurt");
        
        if (_currentHealth<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("enemy die");
        animator.SetBool("IsDead",true);
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
