using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFlyingState : StateMachineBehaviour
{
    Transform playerFeet;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject feather;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerFeet = GameObject.FindGameObjectWithTag("Feet").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(playerFeet);
        float distance = Vector3.Distance(animator.transform.position, playerFeet.position);
        if (distance > 7)
            {
                animator.SetBool("isAttacking", false);
            }
        else if (distance < 2)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isChasing", false);
        }

        if(timeBetweenShots <- 0)
            {
                Instantiate(feather, animator.transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }

            else
            {
                timeBetweenShots -= Time.deltaTime;
            }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
