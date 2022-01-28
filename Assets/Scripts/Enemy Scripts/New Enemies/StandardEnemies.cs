using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemies : MonoBehaviour
{
    public int enemyHealth = 100;
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
