using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemies : MonoBehaviour, IDamageable
{
    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    private bool activeEnemyShield;
    private Rigidbody rb;
    //public GameObject EnemyShieldIndicator;  //HEY SHERRYE i made this pink shield for the rolliepollie just to help myself out while testing.
                                             // Its just a visual indicator of weather or not the shield is broken or not. Feel free to delete. 

    public Animator animator;
    private bool isBouncing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        activeEnemyShield = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(activeEnemyShield == true)
        //{
            //EnemyShieldIndicator.SetActive(true);
        //}
        //else
        //{
            //EnemyShieldIndicator.SetActive(false);
        //}
    }

    public void BreakShield()                           
    {
        activeEnemyShield = false;
        animator.SetTrigger("isBroken");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ForceField")
        {
            BreakShield();
        }     
    }

    public void TakeDamage(int damageAmount)
    {
        if(activeEnemyShield == false)                       
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
     