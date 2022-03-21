using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    
    Transform PlayerTransform;
    public Transform TeleportGoal;


    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("hey hey hey hey hey hey hey");
            PlayerTransform.position = TeleportGoal.position;
        }
    }


}
