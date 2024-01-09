using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    private float _speed=2;
    private float _attackRange=2.2f;
    
    
    private Transform _player;
    private Rigidbody2D _rb;
    private Boss _boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("MainPlayer").transform;
        _rb = animator.GetComponent<Rigidbody2D>();
        _boss = animator.GetComponent<Boss>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player_health.health > 0)
        {
            _boss.LookAtPlayer();
                    Vector2 target = new Vector2(_player.position.x, _rb.position.y);
                    Vector2 newPos = Vector2.MoveTowards(_rb.position, target, _speed * Time.fixedDeltaTime);
                    _rb.MovePosition(newPos);
                    if(Vector2.Distance(_player.position,_rb.position)<= _attackRange)
                    {
                        animator.SetTrigger("Attack");
                    }
        }
        
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}
