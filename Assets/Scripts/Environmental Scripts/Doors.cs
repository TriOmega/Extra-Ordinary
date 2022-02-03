using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject doorKey;
    public GameObject holder;  
    public static bool UIkey = false;
    public GameObject door;
    Transform objectToFollow;
    public Vector3 offset;

    void Start()
    {
        UIkey = false;
    }

    void Update()
    {
        if(UIkey == true)
        {
            objectToFollow = GameObject.Find("Player").transform;
            transform.position = objectToFollow.position + offset;
        }
    }
 

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")  //If the player touches the key item in the game
        {
            holder.SetActive(false); //this makes the key in the overworld disapear. 
            UIkey = true; //This makes the image of a key appear in the lower left of your screen.
        }

        if((other.gameObject.tag == "Door") && (UIkey == true))
        {
            doorKey.SetActive(false);
            door.transform.Rotate(new Vector3(0, 75, 0) );
            UIkey = false;

        }



    }


    
    

}
