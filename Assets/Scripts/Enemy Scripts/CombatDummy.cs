using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    public int EnemyHealth { get => enemyHealth; set => enemyHealth = value; }
    //public bool HasBeenHit { get => hasBeenHit; set => hasBeenHit = value; }

    public void TakeDamage(int damageAmount)
    {
        //hasBeenHit = true;
        EnemyHealth -= damageAmount;
        Debug.Log($"Ow! Dummy took {damageAmount} points of damage and now has {enemyHealth} health.");
        //combatReference = attackerCombatReference
    }

    //private void Update()
    //{
    //    if (!PlayerCombat.isSwordSwinging)
    //    {
    //        hasBeenHit = false;
    //    }
    //}

    //private bool hasBeenHit = false;
    private int enemyHealth = 9999;
}
