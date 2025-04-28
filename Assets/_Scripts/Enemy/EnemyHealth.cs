using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Opponent Health")]
    [SerializeField] float maxHealth = 200;
    [SerializeField] float currentHealth;


    private void Start()
    {
        currentHealth= maxHealth;

    }
    //[SerializeField] private HealthBar healthBar;
    public void TakeDamage(float amout)
    {


        currentHealth -= amout;
      


        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
           // healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    private void Die()
    {

        Destroy(gameObject, 20f);
        this.enabled = false;
        GetComponent<Collider>().enabled = false;

    }
}
