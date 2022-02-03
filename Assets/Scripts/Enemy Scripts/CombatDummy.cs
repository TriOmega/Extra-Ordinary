using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatDummy : MonoBehaviour, IDamageable
{

    public int EnemyHealth { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    public void TakeDamage(int damageAmount)
    {
        if (isInvincible) return;

        EnemyHealth -= damageAmount;
        Debug.Log($"Ow! Dummy took {damageAmount} points of damage and now has {enemyHealth} health.");

        if (!isInvincible)
        {
            StartCoroutine(BeginInvincibility());
        }
    }

    private IEnumerator BeginInvincibility()
    {
        Debug.Log("Dummy Invincible");
        isInvincible = true;
        
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        
        Debug.Log("Dummy Not Invincible");
        isInvincible = false;
    }

    private int enemyHealth = 9999;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 5;
}
