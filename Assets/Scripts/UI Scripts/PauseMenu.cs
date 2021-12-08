using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuGameObject;
    public AudioSource levelBackgroundMusic;

    void Start()
    {
        Resume();   //This is to make sure the game doesn't load initally into a paused state. That was happening (for some reason) until I did this. 
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
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

        //if (Input.GetKeyDown(KeyCode.B))
        //{
           // Time.timeScale = 0f;
           // gameIsPaused = true;

           // if (Input.GetKeyDown(KeyCode.P))
           // {
            //    Resume();
           // }
       // }
    }

    public void Resume()
    {
        pauseMenuGameObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        levelBackgroundMusic.Play();
    }

    void Pause()
    {
        pauseMenuGameObject.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        levelBackgroundMusic.Pause();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
