using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnter : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
         if(collision.CompareTag("Player"))
         {
             SceneManager.LoadScene("BossScene");
         }
    }
}
