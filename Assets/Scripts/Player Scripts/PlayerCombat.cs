using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Collider playerBasicAttackBox;
    public Collider bubblegumAttackBox;
    public LayerMask basicEnemyLayer;
    public float swordKnockbackThrust = 8.0f;
    public float bubblegumKnockbackThrust = 10.0f;
    private Animator anim;

    public int damageAmount = 20;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
             Debug.Log("Debug Activated");
        }

        if (Input.GetAxis("BasicAttack") == 1 )
        {
            anim.SetTrigger("Sword");
        }

        if (BubbleGum.AttackCanGo == true)
        {
            BubbleGum.AttackCanGo = false;
        }
    }

    private void ToggleSwordHitBox (int eventResult)
    {
        switch (eventResult)
        {
            case 0:
                playerBasicAttackBox.enabled = false; 
                break;
            case 1:
                playerBasicAttackBox.enabled = true; 
                break;
        }
    }

    private void BubblegumAttack(Collider bubblegumAttackBox)
    {  
    
        Collider[] cols = Physics.OverlapBox(bubblegumAttackBox.bounds.center, bubblegumAttackBox.bounds.extents, bubblegumAttackBox.transform.rotation, basicEnemyLayer);
        foreach(Collider col in cols)
        {

            Vector3 moveDirection = col.transform.position - this.transform.position;
            col.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * bubblegumKnockbackThrust);
        }
    }

    private void Block()
    {
        Transform targetTransform = (Blocking.projectileTransform == null) ? playerBasicAttackBox.transform : Blocking.projectileTransform;
        Vector3 tempPosition = targetTransform.position;
        tempPosition.y = this.transform.position.y;
        targetTransform.position = tempPosition;
        //Debug.Log(targetTransform);
        this.transform.LookAt(targetTransform);
    }
    /*Current Block() Flaws: 1. Adjusts target transform too (if projectiles get destroyed on block anyways we might not need to worry)
                             2. Transform doesn't get reset after blocking ends, possible fix is to figure out how to implement OnTriggerEnter for the PlayerCombat script*/
}
