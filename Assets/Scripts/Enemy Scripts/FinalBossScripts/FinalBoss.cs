using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{


    public static bool BossTookDamage = false;
   



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(BossTookDamage == true)
        {
            
        }
    }


    
    private void OnTriggerEnter(Collider collision)
    {

        if(collision.CompareTag("Sword"))
        {
            if(PlayerCombat.AttackPressed == true)
            {
                BossTookDamage = true;
            }
        }
    }


}
