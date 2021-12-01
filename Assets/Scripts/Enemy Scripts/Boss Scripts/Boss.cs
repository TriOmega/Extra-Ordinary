using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public static int bossHealth = 100;


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Sword") && PlayerCombat.swordHasSwung == true)
        {
            bossHealth = bossHealth - 5;
            Debug.Log("health is " +bossHealth);
            PlayerCombat.swordHasSwung = false;
            
            if(bossHealth <= 0)
            {
                Destroy(this.gameObject, 1);
            }
        }
    }

}
