using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiredPanting : StateMachineBehaviour
{
    GameObject player;
    
    private Transform playerPosition;
    private Rigidbody BossCurrentPosition;
    float timeRemaining =10;




    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        BossCurrentPosition = animator.GetComponent<Rigidbody>();
        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.1f;  //Slow Mateo down 
 
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = playerPosition.position;  //Follow the player

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 5)
        {
            animator.SetTrigger("Transition5");
            timeRemaining = 8f;
        }

        if(FinalBoss.BossTookDamage == true)
        {
            animator.SetTrigger("BossTookDamage");
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("BossTookDamage");
    }
}
