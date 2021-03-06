using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : StateMachineBehaviour
{

    Transform playerTransform;

    Rigidbody bossRigidbody;
    AudioSource bossMusic;
    AudioSource awakeSound;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bossRigidbody = bossRigidbody = animator.GetComponent<Rigidbody>();
        bossMusic = GameObject.Find("bossMusic").GetComponent<AudioSource>();
        awakeSound = GameObject.Find("awakeSound").GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(playerTransform.position, bossRigidbody.position) <= 5) //5 is the number of feet away from Mateo until you wake him up. We can change this.
        {
            animator.SetTrigger("BossActive");
            bossMusic.Play();
            awakeSound.Play();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
