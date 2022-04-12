using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTaunt : StateMachineBehaviour
{

    Transform playerTransform;
    Rigidbody bossRigidbody;



    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bossRigidbody = animator.GetComponent<Rigidbody>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(playerTransform.position, bossRigidbody.position) <= 5) //5 is the number of feet away from Mateo until you wake him up. We can change this.
        {
            animator.SetTrigger("FinalBossActive");
            //bossMusic.Play();  //boss music plays on awake
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


}
