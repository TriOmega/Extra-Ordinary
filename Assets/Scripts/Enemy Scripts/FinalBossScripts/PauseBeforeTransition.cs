using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBeforeTransition : StateMachineBehaviour
{

    float timeRemaining;



    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining = 10f;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 9.2)
        {
            animator.SetTrigger("Transition3");
            timeRemaining = 10f;
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Transition3");
    }


}
