using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth = 10;
    public float MaxHealth = 10;
    public float damageTaken = 1f;

    public float regeneration = 0.5f;

    public float damageTimer = 1f;
    private bool canTakeDamage = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            CurrentHealth -= damageTaken;
            //  StartCoroutine(damageTimeout(damageTimer));
        }

        if (collision.gameObject.tag == "health" && canTakeDamage && CurrentHealth <= 9)
        {
            CurrentHealth++;
        }
    }

    public void Update()
    {
        AdjustCurrentHealth(0);

        if (CurrentHealth < MaxHealth)
            CurrentHealth += regeneration * Time.deltaTime;
    }

    private IEnumerator damageTimeout(float timer)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(timer);
        canTakeDamage = true;
    }


    public void AdjustCurrentHealth(int adj)
    {
        CurrentHealth += adj;
        if (CurrentHealth < 0)
            CurrentHealth = 0;
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
        if (MaxHealth < 1)
            MaxHealth = 1;
    }
}
