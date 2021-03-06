using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingState : StateMachineBehaviour
{
    float timer;
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 7;
    WaypointRefs waypointScript;
    [SerializeField]
    string quickAttackStateName;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        waypointScript = animator.GetComponent<WaypointRefs>();

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypointScript.waypoints[0].position);
        player = GameObject.FindGameObjectWithTag("Feet").transform;
        animator.SetBool("isBlocking", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (timer > 10)
            {
                animator.SetBool("isPatrolling", false);
            }

        if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(waypointScript.waypoints[Random.Range(0, waypointScript.waypoints.Count)].position);
            }

        if (distance < chaseRange)
            {
                animator.SetBool("isChasing", true);
                if (!string.IsNullOrEmpty(quickAttackStateName))
                {
                    animator.Play(quickAttackStateName);
                }
                
            }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
