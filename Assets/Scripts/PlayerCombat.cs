using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers; 
    public float blockAttack = 0.9f;
    
    private float _nextAttackTime = 0f;
    private int _attacakDamage=30;
    void Update()
    {
        if (Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                 
                animator.SetTrigger("Attack");
              PlayerController.moveSpeed = 0.1f;
              StartCoroutine(slowCharacter());
              _nextAttackTime = Time.time + blockAttack;
              
            }
        }
        
    }

    private IEnumerator slowCharacter()
    {
        yield return new WaitForSeconds(0.6f);
        PlayerController.moveSpeed = 8;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
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
