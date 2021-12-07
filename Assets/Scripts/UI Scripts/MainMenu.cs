using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Vertical_Slice");
    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game.");
        Application.Quit();        
    }
}
