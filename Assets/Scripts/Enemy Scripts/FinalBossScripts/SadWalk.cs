using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadWalk : StateMachineBehaviour
{
    GameObject player;
    
    private Transform playerPosition;
    private Rigidbody BossCurrentPosition;
    float distanceFromPlayer = 1f;
    float timeRemaining;




    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        BossCurrentPosition = animator.GetComponent<Rigidbody>();
        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 1;  //Slow Mateo down while he's doing the sad walk. 
        timeRemaining = 10f; 
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = playerPosition.position;  //Follow the player

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 6.5)
        {
            animator.SetTrigger("Transition4");
            timeRemaining = 10f;
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 3.5f;
        animator.ResetTrigger("Transition4");
    }
}
