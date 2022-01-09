using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunning : StateMachineBehaviour
{
    Rigidbody bossRigidbody;
    Transform bossLocation;
    float runSpeed = 4f;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossRigidbody = animator.GetComponent<Rigidbody>();
        bossLocation = animator.GetComponent<Transform>();
        bossLocation.transform.Rotate(0, -90, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 runTarget = new Vector3(208.72f, bossRigidbody.position.y, -323f);
        Vector3 newPosition = Vector3.MoveTowards(bossRigidbody.position, runTarget, runSpeed * Time.fixedDeltaTime);
        bossRigidbody.MovePosition(newPosition);

        if (bossRigidbody.position.z >= -323.5)
        {
            animator.SetTrigger("StartCastingMagic");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossLocation.transform.Rotate(0, 180, 0);
    }
}
