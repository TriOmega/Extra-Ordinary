using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemies : MonoBehaviour, IDamageable
{
    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
         if (isInvincible) return;

        Health -= damageAmount;
        

        if (!isInvincible)
        {
            StartCoroutine(BeginInvincibility());
        }

        if(enemyHealth <= 0)
        {
            //Death animation + sound
            animator.SetTrigger("isKilled");
            Destroy(this.gameObject, 1);
        }
        else
        {
            animator.SetTrigger("isDamaged");
            //Damage Sound + animation if we need it
        }
    }

    private IEnumerator BeginInvincibility()
    {
        isInvincible = true;
        
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        
        isInvincible = false;
    }

    private int enemyHealth = 100;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
}
