using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject holder;  
    public GameObject SoundEffectPlayer;
    public static bool UIkey = false;
    public GameObject door;
    float timeRemaining;
    Transform objectToFollow;
    public Vector3 offset;
    bool IsKeyObtained;
    bool shouldTimerBeStarted;
    float rotateAngle = 30f; 
    bool oneKeyIsPressedDown;

    

    void Start()
    {
        UIkey = false;
        IsKeyObtained =false;
        objectToFollow = GameObject.Find("Player").transform;
        timeRemaining = 160f;
        shouldTimerBeStarted = false;

    }

    void Update()
    {
        if(IsKeyObtained == true)
        {
            transform.position = objectToFollow.position + offset;  //This makes the key follow the player. It has to be in update to work.
        }

        if(shouldTimerBeStarted == true)
        {
            timeRemaining -= Time.deltaTime;    //This starts the countdown timer. It has to be in update to work. 
        }



        oneKeyIsPressedDown = Input.GetKey(KeyCode.Alpha1);



        if(timeRemaining <= 2)
        {
            objectToFollow = door.transform;
        }

        if((timeRemaining <= 1.5) && (timeRemaining >= -4))
        {
            holder.SetActive(false);  //this makes the key invisible 
            UIkey = false;
            door.transform.Rotate(Vector3.up * rotateAngle * Time.deltaTime);  //This opens the door
            SoundEffectPlayer.SetActive(true);
            IsKeyObtained = false;      
        }

        if(timeRemaining <= -10)
        {
            IsKeyObtained = false;
            UIkey = false;
            Destroy(this.gameObject); 
        }




    }
 

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")  
        {
            holder.SetActive(false); 
            UIkey = true; //This makes the image of a key appear in the lower left of your screen.
            IsKeyObtained = true;
        }

        if((other.gameObject.tag == "Door") && (IsKeyObtained = true))
        {
            holder.SetActive(true); 
            UIkey = false;  
            //if(oneKeyIsPressedDown)   //This makes you press the "1" key before the door opens.
            {
                timeRemaining = 3;
                shouldTimerBeStarted = true;
            }

        }

        
 
    }



    public void OnTriggerExit(Collider other)
    {
        if((other.gameObject.tag == "Door") && (IsKeyObtained = true))
        {
            holder.SetActive(false);  //This makes the key invisible in the overworld       
            UIkey = true;  //this turns on the UI
        }
    }


    



    
    

}
