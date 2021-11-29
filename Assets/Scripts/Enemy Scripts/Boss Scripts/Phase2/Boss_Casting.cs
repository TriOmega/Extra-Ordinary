using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Casting : StateMachineBehaviour
{

    public GameObject forcefield;
    Transform forcefieldSpawner;
    float timeRemaining;
    bool isDone = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining = 10f;
        forcefieldSpawner = GameObject.FindGameObjectWithTag("Shockwave").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 9)
        {
            if (!isDone)
            {
                Instantiate (forcefield, forcefieldSpawner.position, forcefieldSpawner.rotation);
                isDone = true;
                animator.SetTrigger("StartThrowingBombs");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isDone = false;
    }


}
