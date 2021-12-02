using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeathAnimation : StateMachineBehaviour
{

    AudioSource awakeSound;
    GameObject bossMusic = GameObject.Find("bossMusic");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        awakeSound = GameObject.Find("awakeSound").GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("bossHealth " +Boss.bossHealth);

        if(Boss.bossHealth <=0 )
        {
            Debug.Log("here");
            bossMusic.SetActive(false);
            awakeSound.Play();
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Continue");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Continue");
    }


}
