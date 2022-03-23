using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    
    public GameObject player;
    public Transform teleportGoal;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("hey hey hey hey hey hey hey");
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = teleportGoal.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }


}
