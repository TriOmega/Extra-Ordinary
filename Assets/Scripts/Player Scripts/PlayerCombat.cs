using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour

{
    public static bool swordHasSwung = false;
    public Collider basicPlayerAttackBox;
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
        if (Input.GetAxis("BasicAttack") == 1)
        {
            BasicAttack(basicPlayerAttackBox);
            anim.SetTrigger("Sword");
            swordHasSwung = true;
        }
        
        //if (Input.GetAxis("Block") == 1)
        //{
        //    Block();
        //}    

        if (BubbleGum.AttackCanGo == true)
        {
            //BubblegumAttack(bubblegumAttackBox);
            BubbleGum.AttackCanGo = false;
        }
    }

    private void BasicAttack(Collider attackBox)
    {
        Collider[] cols = Physics.OverlapBox(attackBox.bounds.center, attackBox.bounds.extents, attackBox.transform.rotation, basicEnemyLayer);
        foreach(Collider col in cols)
        {
            Vector3 moveDirection = col.transform.position - this.transform.position;
            col.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * swordKnockbackThrust);

            var e = col.GetComponent<IDamageable>();
            //StandardEnemies e = col.transform.GetComponent<StandardEnemies>(); //Enemies take damage 
            if (e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }
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
        Transform targetTransform = (Blocking.projectileTransform == null) ? basicPlayerAttackBox.transform : Blocking.projectileTransform;
        Vector3 tempPosition = targetTransform.position;
        tempPosition.y = this.transform.position.y;
        targetTransform.position = tempPosition;
        //Debug.Log(targetTransform);
        this.transform.LookAt(targetTransform);
    }
    /*Current Block() Flaws: 1. Adjusts target transform too (if projectiles get destroyed on block anyways we might not need to worry)
                             2. Transform doesn't get reset after blocking ends, possible fix is to figure out how to implement OnTriggerEnter for the PlayerCombat script*/
}
