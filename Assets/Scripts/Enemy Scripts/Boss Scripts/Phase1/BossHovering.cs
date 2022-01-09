using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHovering : StateMachineBehaviour
{
    Transform playerTransform;
    Rigidbody bossRigidbody;
    bool canAttack = false;
    
    float speed = 2f; //How quickly the brother moves from left to right when following the kiddo.



    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bossRigidbody = animator.GetComponent<Rigidbody>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(playerTransform.position.x, 168, playerTransform.position.z);
        Vector3 newPosition = Vector3.MoveTowards(bossRigidbody.position, target, speed * Time.fixedDeltaTime);
        bossRigidbody.MovePosition(newPosition);

        if (bossRigidbody.position.y >= 167.5)
        {
            canAttack = true;
        }

        if ((Vector3.Distance(playerTransform.position, bossRigidbody.position) <= 3.6f) && canAttack == true)  //3.6 is the number of feet away from Mateo until he does a ground pound attack
        {
            animator.SetTrigger("GroundPoundAttack");
            canAttack = false;         
        }

        if (Boss.bossHealth < 66)
        {
            animator.SetTrigger("GroundPoundAttack");
            canAttack = false;  
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("GroundPoundAttack");   
    }

}
