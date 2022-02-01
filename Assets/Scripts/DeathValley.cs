using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathValley : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Reset");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, 0);
        }
    }
}
