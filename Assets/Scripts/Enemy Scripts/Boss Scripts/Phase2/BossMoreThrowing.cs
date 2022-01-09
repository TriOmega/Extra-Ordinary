using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoreThrowing : StateMachineBehaviour
{

    Transform BombSpawner;
    public GameObject bombPrefab;
    float timeRemaining;
    bool isDone = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining = 10f;
        BombSpawner = GameObject.FindGameObjectWithTag("Bomb").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 9.2)
        {
            if (!isDone)
            {
                Instantiate (bombPrefab, BombSpawner.position, BombSpawner.rotation);
                isDone = true;

            }

            if(animator.GetBool("HitByBomb") == false)
            {
                animator.SetTrigger("StartThrowingBombs");
            }
        }
            
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isDone = false;
        animator.ResetTrigger("StartThrowingBombs");
    }

}
