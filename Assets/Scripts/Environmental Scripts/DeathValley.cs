using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathValley : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealthScript;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerHealthScript.checkpointHandler.ResetToLastCheckpoint();
        }
    }
}
