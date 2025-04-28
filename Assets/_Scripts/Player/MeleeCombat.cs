using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{



    Animator animator;
    bool activateSwordAttack;
    
    [SerializeField] Collider[] hitOpponent;
    [SerializeField] EnemyHealth enemyHealth;


    [SerializeField] Vector3 attackArea;
    [SerializeField] float attackingRadius;
    [SerializeField] float giveDamage = 10f;
    [SerializeField] LayerMask OpponentLayer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateMeeleAttackMode();
    }

    private void ActivateMeeleAttackMode()
    {
        if (Input.GetMouseButtonDown(1))
        {
            activateSwordAttack = !activateSwordAttack; //toggle 
            if (activateSwordAttack)
            {
                animator.SetBool("Sword _Attack", true);
            }
            else
            {
                animator.SetBool("Sword _Attack", false);
            }
        }

        MeleeAttack();
    }

    private void MeleeAttack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Attack_1", true);
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Attack_2", true);
            Attack();
        }
        else
        {
            animator.SetBool("Attack_1", false);
            animator.SetBool("Attack_2", false);
        }
    }

    void Attack()
    {
        hitOpponent = Physics.OverlapSphere(transform.TransformPoint(attackArea), attackingRadius, OpponentLayer);
        foreach (Collider opponent in hitOpponent)
        {
            enemyHealth = opponent.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(giveDamage);
            }
        }
    }


    //(transform.TransformPoint(surfaceCheckOffset)
    private void OnDrawGizmosSelected()
    {

        if (attackArea == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.TransformPoint(attackArea), attackingRadius);
    }
}
