using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 200;
    [SerializeField] float currentHealth;
    [SerializeField] Animator animator;
    //[SerializeField] private HealthBar healthBar;

    //[SerializeField] GameObject GameOverPanel;

    private void Start()
    {
        //healthBar.UpdateHealthBar(maxHealth, currentHealth);
       // animator = GetComponent<Animator>();

    }

    public float setMaxHealth(float MaxHealth)
    {
        currentHealth = maxHealth;
        return maxHealth = MaxHealth;

       
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            //healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    

    private void Die()
    {
        //Destroy(gameObject);
        //GameOverPanel.SetActive(true);
        //animator.SetTrigger("Death");
        StartCoroutine("PauseGame", 4f);

    }

    IEnumerator PauseGame()
    {

        Time.timeScale = 0.2f;
        yield return null;

    }
}
