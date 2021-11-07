using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("BuildScene");
    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game. I always knew you were a quitter.");
        Application.Quit();        
    }

}
