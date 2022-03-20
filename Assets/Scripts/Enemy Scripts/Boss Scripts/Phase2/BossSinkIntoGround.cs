using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSinkIntoGround : StateMachineBehaviour
{


    GameObject sinkTarget;
    Vector3 targetVector;
    Transform bossTransform;
    float decendSpeed = 0.5f;
    float timeRemaining;
    AudioSource deathSound;
    AudioSource bossMusic;




    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sinkTarget = GameObject.Find("sinkTarget");
        targetVector = sinkTarget.transform.position;
        bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
        deathSound = GameObject.Find("deathSound").GetComponent<AudioSource>();
        bossMusic = GameObject.Find("bossMusic").GetComponent<AudioSource>();
        timeRemaining = 10f;
        deathSound.Play();
        bossMusic.Stop();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 4)
        {
            float step = decendSpeed * Time.deltaTime;
            bossTransform.position = Vector3.MoveTowards(bossTransform.position, targetVector, step);
        }

        if (timeRemaining < 2)
        {
            SceneManager.LoadScene("AustinScene");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


}
