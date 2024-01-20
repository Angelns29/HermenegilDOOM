using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Damage;


public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private FloatValueSO currentHealth;

    [SerializeField] private float flashTime = 0.2f;

    private void Start()
    {
        currentHealth.Value = 1;
    }

    public void Reduce(int damage)
    {
        currentHealth.Value -= damage / maxHealth;
        if (currentHealth.Value <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int healthBoost)
    {
        int health = Mathf.RoundToInt(currentHealth.Value * maxHealth);
        int val = health + healthBoost;
        currentHealth.Value = (val > maxHealth ? maxHealth : val / maxHealth);
    }

    private void Die()
    {
        Debug.Log("Died");
        currentHealth.Value = 1;
    }

    public void TakeDamage(float damage)
    {
        if (maxHealth>0) 
        {
            //currentHealth -= damage / maxHealth;
        }
    }
}

