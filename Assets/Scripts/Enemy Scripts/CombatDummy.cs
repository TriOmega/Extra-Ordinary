using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatDummy : MonoBehaviour, IDamageable
{

    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    public void TakeDamage(int damageAmount)
    {
        if (isInvincible) return;

        Health -= damageAmount;
        Debug.Log($"Ow! Dummy took {damageAmount} points of damage and now has {enemyHealth} health.");

        if (!isInvincible)
        {
            StartCoroutine(BeginInvincibility());
        }
    }

    private IEnumerator BeginInvincibility()
    {
        isInvincible = true;
        
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        
        isInvincible = false;
    }

    private int enemyHealth = 9999;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
}
