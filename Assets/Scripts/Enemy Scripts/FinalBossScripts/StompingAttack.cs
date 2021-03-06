using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingAttack : StateMachineBehaviour
{

    GameObject foot;
    public GameObject shockwave;
    bool isDone;
    float timeRemaining;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foot = GameObject.Find("ShockwaveGenerator"); 
        timeRemaining = 10f; 
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 shockwaveLocation = new Vector3(foot.transform.position.x, foot.transform.position.y, foot.transform.position.z);
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 9.3)
        {
            if (!isDone)
            {
                Instantiate (shockwave, shockwaveLocation, foot.transform.rotation);
                isDone = true;
            }
        }


    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //animator.ResetTrigger("ActivatePunchingAttack");
        isDone = false;
    }

}
