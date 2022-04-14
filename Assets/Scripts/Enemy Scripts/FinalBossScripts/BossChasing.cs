using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChasing : StateMachineBehaviour
{

    GameObject player;
    BoxCollider BossAttackHitbox;
    private Transform playerPosition;
    private Rigidbody BossCurrentPosition;
    float distanceFromPlayer = 1f;




    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossAttackHitbox = GameObject.Find("BossAttackHitbox").GetComponent<BoxCollider>();
        BossAttackHitbox.enabled = false;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        BossCurrentPosition = animator.GetComponent<Rigidbody>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = playerPosition.position;


        if(Vector3.Distance(BossCurrentPosition.position, playerPosition.position) < distanceFromPlayer)   //Punch the player if he gets close enough.
        {
            BossAttackHitbox.enabled = true;
            animator.SetTrigger("ActivatePunchingAttack");
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("ActivatePunchingAttack");
    }
}
