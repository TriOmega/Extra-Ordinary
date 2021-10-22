using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour

{
    public GameObject swordPivot;
    public Collider basicPlayerAttackBox;
    public LayerMask basicEnemyLayer;
    public float knockbackThrust = 10.0f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            swordPivot.GetComponent<Animator>().Play("sword_slash");
            BasicAttack(basicPlayerAttackBox);
        }
    }

    private void BasicAttack(Collider attackBox)
    {
        Collider[] cols = Physics.OverlapBox(attackBox.bounds.center, attackBox.bounds.extents, attackBox.transform.rotation, basicEnemyLayer);
        foreach(Collider col in cols)
        {
            //DamageEnemyHealth() method here

            Vector3 moveDirection = col.transform.position - this.transform.position;
            col.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * knockbackThrust);
        }
    }
}
