using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDying : StateMachineBehaviour
{



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if(Boss.bossHealth <= 0)
        {
            animator.SetTrigger("ActivateDeath");
            //KillBoss();
        }
        if(Boss.bossHealth > 1)
        {
            animator.SetTrigger("Continue");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


   /* IEnumerator KillBoss()
    {
        yield return new WaitForSeconds (3f);
        SceneManager.LoadScene("AustinScene");
    }*/

}
