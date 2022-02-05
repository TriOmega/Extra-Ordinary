using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemies : MonoBehaviour
{
     public int enemyHealth = 100;
     public Animator animator;
     private bool activeShield;
    
    // Start is called before the first frame update
    void Start()
    {
        activeShield = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakShield()                           //Eric: There were compilation errors so I changed this from returning a bool to void
    {
        activeShield = false;
    }

    public void TakeDamage(int damageAmount)
    {
        if(activeShield == false)                       //Eric: There were compilation errors so I changed this to == from =
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
}
