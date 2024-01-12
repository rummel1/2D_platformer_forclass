using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 20;
    	public int enragedAttackDamage = 40;
    
    	public Vector3 attackOffset;
    	public float attackRange = 1f;
    	public LayerMask attackMask;
    
    	public void Attack()
    	{
	        if (Player_health.currentHealth > 0)
	        {
		        Vector3 pos = transform.position;
		        pos += transform.right * attackOffset.x;
		        pos += transform.up * attackOffset.y;
                    
		        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		        if (colInfo != null) {
			        colInfo.GetComponent<Player_health>().TakeDamage(attackDamage);
		        }
	        }
    		
    	}
    
    	public void EnragedAttack()
    	{
    		Vector3 pos = transform.position;
    		pos += transform.right * attackOffset.x;
    		pos += transform.up * attackOffset.y;
    
    		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
    		if (colInfo != null)
    		{
    			colInfo.GetComponent<Player_health>().TakeDamage(enragedAttackDamage);
    		}
    	}
    
    	void OnDrawGizmosSelected()
    	{
    		Vector3 pos = transform.position;
    		pos += transform.right * attackOffset.x;
    		pos += transform.up * attackOffset.y;
    
    		Gizmos.DrawWireSphere(pos, attackRange);
    	}
}
