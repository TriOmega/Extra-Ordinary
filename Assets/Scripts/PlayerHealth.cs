using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 10;
    public float maxHealth = 10;
    public float damageTaken = 1f;
    public int lives = 3; 

    public float regeneration = 0.5f;

    public float damageTimer = 1f;
    private bool canTakeDamage = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            currentHealth -= damageTaken;
            //  StartCoroutine(damageTimeout(damageTimer));
        }

        if (collision.gameObject.tag == "health" && canTakeDamage && currentHealth <= 9)
        {
            currentHealth++;
        }
    }

    public void Update()
    {
        AdjustCurrentHealth(0);

        if (currentHealth < maxHealth)
            currentHealth += regeneration * Time.deltaTime;
    }

    private IEnumerator damageTimeout(float timer)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(timer);
        canTakeDamage = true;
    }


    public void AdjustCurrentHealth(int adj)
    {
        currentHealth += adj;
        if (currentHealth < 0)
            currentHealth = 0;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
    }
}
