using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{


    public static bool BossTookDamage = false;
    float timeRemaining;
    



    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 10f;
    }

    // Update is called once per frame
    void Update()
    {


        if(BossTookDamage == true)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 9.5)
        {
            BossTookDamage = false;
            timeRemaining = 10f;
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
