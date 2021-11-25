using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_GroundPound : StateMachineBehaviour
{
    Rigidbody bossRigidbody;
    public GameObject shockwave;

    bool isDone;

    float dropSpeed = 8f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossRigidbody = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dropTarget = new Vector3(bossRigidbody.position.x, 163.86f, bossRigidbody.position.z);
        Vector3 dropPosition = Vector3.MoveTowards(bossRigidbody.position, dropTarget, dropSpeed * Time.fixedDeltaTime);
        bossRigidbody.MovePosition(dropPosition);


        Vector3 shockwaveLocation = new Vector3(bossRigidbody.position.x, 164f, bossRigidbody.position.z);
        if(bossRigidbody.position.y <= 164)
        {
            if (!isDone)
            {
                Instantiate (shockwave, shockwaveLocation, bossRigidbody.rotation);
                isDone = true;
            }
        }


        animator.SetTrigger("PoundAttackFinished");         

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isDone = false;
        animator.ResetTrigger("PoundAttackFinished"); 
    }


}

