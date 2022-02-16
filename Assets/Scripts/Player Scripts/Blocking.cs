using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{

    float timeRemaining;
    public static bool isBlocking; //This variable is used in the "PlayerHealth" script, it checks to see if the player is able to take damage. 
    bool isShiftKeyDown = false;
    public GameObject forceFieldBubble;
    public CharController playerCharController;
    private Animator anim;


    void Start () 
    {
        timeRemaining = 2;
        isBlocking = false;
        anim = GetComponent<Animator>();
    }
    

    void Update () 
    {
    
        timeRemaining -= Time.deltaTime; 

        isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);  
        //For some reason unity doesn't recognize just "Shift," You have to specify left and right.

        if(isShiftKeyDown == true)
        {   

            if(timeRemaining > 0)
            {
                isBlocking = true;
                playerCharController.PauseMovement();
                forceFieldBubble.SetActive(true);
                anim.SetBool("Blocking", true);
            }
            if (timeRemaining <= 0)
            {
                isBlocking = false;
                forceFieldBubble.SetActive(false);
                anim.SetBool("Blocking", false);
                playerCharController.ResumeMovement();
            } 

        }
        else
        {
            isBlocking = false;
            forceFieldBubble.SetActive(false);
            anim.SetBool("Blocking", false);
            playerCharController.ResumeMovement();
            timeRemaining = 2;
        }


    }
        



}
