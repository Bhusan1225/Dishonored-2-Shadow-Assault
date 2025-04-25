using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{



    Animator animator;
    bool activateSwordAttack;

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
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Attack_2", true);
        }
        else
        {
            animator.SetBool("Attack_1", false);
            animator.SetBool("Attack_2", false);
        }
    }
}
