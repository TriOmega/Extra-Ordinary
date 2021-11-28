using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUIgameobject;

    void Start ()
    {
        Resume ();   //This is to make sure the game doesn't load initally into a paused state. That was happening (for some reason) until I did this. 
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUIgameobject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUIgameobject.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("PCBJodyWhitebox");
    }

}
