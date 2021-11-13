using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGum : MonoBehaviour
{

    float scaleRate = 0.0015f;  //How fast the bubblegum fluctuates
    float deployRate =0.3f; //How fast the bubblegum deploys initially
    float minScale = 3.0f;
    float maxScale = 3.5f;

    bool gumActive = false;
    public static bool AttackCanGo = false;
    bool allowedToUseGum = true;

 

    int jumpCounter = 0;
    float gumGravity = -40f;
    float gumJumpHeight = 3f;
    
    // public void OnTriggerEnter(Collider other)
    // {
    //     //if(other.gameObject.tag == "Stalactite")
    //     {
    //         gumActive = false;
    //         allowedToUseGum = false;
    //         AttackCanGo = true;
    //     }
    // }


    
    public void Update() 
    {

        if(Input.GetButtonDown("Fire2") && allowedToUseGum == true)  //Click the right mouse button to deploy bubblegum!
        {
            transform.localScale += (Vector3.one * deployRate);  //Quickly inflate bubble
            gumActive = true;
            CharController.velocity.y = Mathf.Sqrt(gumJumpHeight * -2f * gumGravity); //jump
            jumpCounter += 1;
        }



        //if we exceed the defined range then correct the sign of scaleRate.
        if(transform.localScale.x < minScale) 
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if(transform.localScale.x > maxScale) 
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }


        if(gumActive == true)
        {
            transform.localScale += (Vector3.one * scaleRate);  //This applies the slow fluxuating size effect.
        }
        else
        {
            transform.localScale = new Vector3(0.0001f,0.0001f,0.0001f);  //makes the gum very very very tiny if its not in use.
        }




        if(jumpCounter >= 3)
        {
            gumActive = false;
            allowedToUseGum = false;
            AttackCanGo = true;
            jumpCounter = 0;
        }

        if(CharController.isGrounded == true)
        {
            gumActive = false;
        }

        if ((allowedToUseGum == false) && CharController.isGrounded == true)
        {
            allowedToUseGum = true;
        }

        if ((jumpCounter >= 1) && (CharController.isGrounded == true))
        { 
            AttackCanGo = true;
            jumpCounter = 0;
        }

    }
    







}
