using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemies : MonoBehaviour, IDamageable
{
    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    private bool activeShield;
    private Rigidbody rb;

    public Animator animator;
    private bool isBouncing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        activeShield = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
 
    }

    public void BreakShield()                           
    {
        activeShield = false;
        animator.SetTrigger("isBroken");
    }

    public void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "ForceField")
        {
            BreakShield();
        }
     
    }

    public void TakeDamage(int damageAmount)
    {
        if(activeShield == false)                       
        {
            enemyHealth -= damageAmount;
        
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
    }

    private int enemyHealth = 100;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;

}
     