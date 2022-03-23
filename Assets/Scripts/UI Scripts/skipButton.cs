using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipButton : MonoBehaviour
{
    public string SceneName ;
    
    public void PlayGame()
    {
        SceneManager.LoadScene( SceneName );
    }
}
