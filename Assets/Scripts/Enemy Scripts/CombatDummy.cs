using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    private int enemyHealth = 9999;

    public int EnemyHealth { get => enemyHealth; set => enemyHealth = value; }

    public void TakeDamage(int damageAmount)
    {
        EnemyHealth -= damageAmount;
        Debug.Log($"Ow! Dummy took {damageAmount} points of damage and now has {enemyHealth} health.");

    }
}
