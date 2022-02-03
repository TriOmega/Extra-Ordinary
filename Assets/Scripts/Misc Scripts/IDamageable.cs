using System.Collections;
using UnityEngine;

public interface IDamageable
{
    int EnemyHealth { get; set; }
    bool IsInvincible { get; }
    float InvincibilityDurationSeconds { get; }
    void TakeDamage(int damageAmount);
}
