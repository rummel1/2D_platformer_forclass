using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_hit : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public int maxHealth = 100;
    private int _currentHealth;
    [SerializeField] private AudioClip _bosshit;
    [SerializeField] private AudioClip _bossdeath;
    void Start()
    {
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void BossTakeDamage(int damage)
    {
        _currentHealth -= damage;

        SoundManager.instance.PlaySound(_bosshit);
        animator.SetTrigger("Hit");
        
        if (_currentHealth<=0)
        {
            SoundManager.instance.PlaySound(_bossdeath);
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
