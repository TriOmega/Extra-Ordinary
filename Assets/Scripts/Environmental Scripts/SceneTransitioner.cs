using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{

    public string SceneName;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene( SceneName );
        }
    }
}
