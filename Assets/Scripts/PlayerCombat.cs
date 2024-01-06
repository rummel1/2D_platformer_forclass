using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    private int _attacakDamage=30;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
          enemy.GetComponent<EnemyHit>().TakeDamage(_attacakDamage);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        
    }
}
