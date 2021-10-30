using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour

{
    //public Blocking Block { get; set; }

    public GameObject swordPivot;
    public Collider basicPlayerAttackBox;
    public Collider bubblegumAttackBox;
    public LayerMask basicEnemyLayer;
    public float swordKnockbackThrust = 8.0f;
    public float bubblegumKnockbackThrust = 10.0f;
    public enemyController enemy;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            swordPivot.GetComponent<Animator>().Play("sword_slash");
            BasicAttack(basicPlayerAttackBox);
        }
        
        if (Input.GetButton("Block"))
        {
            swordPivot.GetComponent<Animator>().Play("sword_block");
            
        }    

        if (BubbleGum.AttackCanGo == false)
        {
            BubblegumAttack(bubblegumAttackBox);
        }
    }

    private void BasicAttack(Collider attackBox)
    {
        Collider[] cols = Physics.OverlapBox(attackBox.bounds.center, attackBox.bounds.extents, attackBox.transform.rotation, basicEnemyLayer);
        foreach(Collider col in cols)
        {
            enemy.Damaged(10);

            Vector3 moveDirection = col.transform.position - this.transform.position;
            col.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * swordKnockbackThrust);
        }
    }


    private void BubblegumAttack(Collider bubblegumAttackBox)
    {  
    
        Collider[] cols = Physics.OverlapBox(bubblegumAttackBox.bounds.center, bubblegumAttackBox.bounds.extents, bubblegumAttackBox.transform.rotation, basicEnemyLayer);
        foreach(Collider col in cols)
        {
            enemy.Damaged(10);

            Vector3 moveDirection = col.transform.position - this.transform.position;
            col.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * bubblegumKnockbackThrust);
        }

    }
}
