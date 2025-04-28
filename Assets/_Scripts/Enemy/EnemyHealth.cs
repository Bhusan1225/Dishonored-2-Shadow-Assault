using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Opponent Health")]
    [SerializeField] float maxHealth = 200;
    [SerializeField] float currentHealth;
    [SerializeField] Animator animator;


    [SerializeField] EnemyAI enemyAI;

    private void Start()
    {
        currentHealth= maxHealth;
        //animator = GetComponent<Animator>();

    }
    //[SerializeField] private HealthBar healthBar;
    public void TakeDamage(float amout)
    {


        currentHealth -= amout;
      


        if (currentHealth <= 0  )
        {
            enemyAI.setEnemyDeath(true);
            //animator.SetBool("Walk", false);
            //animator.SetBool("Idle", false);
            Die();
        }
       
    }

    private void Die()
    {
       
        animator.SetBool("isDead", true);
        //animator.SetTrigger("Dead");
        Destroy(gameObject, 7f);
        //this.enabled = false;
        //GetComponent<Collider>().enabled = false;

    }
}
