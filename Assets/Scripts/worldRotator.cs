using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldRotator : MonoBehaviour
{

    public GameObject theEntireWorld;
    bool rotateRequest = false;
    float rotateAngle = 30f;  //the angle at which the camera rotates every second
    float rotateTimeAmount;
    float timeRemaining;  //This is a timer that runs. It will tell the world to stop rotating after the number of seconds reaches a certain amount. 
    
 
    void Start()
    {
        timeRemaining = 10f;
    }

    void Update()
    {

        if((rotateRequest == true) && (timeRemaining > 6.9f))  //6.9 is th enumber of seconds the world rotates before stopping. 
        {
            timeRemaining -= Time.deltaTime;
            theEntireWorld.transform.RotateAround(gameObject.transform.position, Vector3.up, rotateAngle * Time.deltaTime);
        }
           

    }
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            rotateRequest = true;
        }
    }




}
