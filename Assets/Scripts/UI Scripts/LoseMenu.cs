using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseStateMenuGameObject;
    private GameObject _player;

    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.GetComponent<PlayerHealth>().NoMoreLives += LoseScreen;
        loseStateMenuGameObject.SetActive(false);
    }

    public void LoseScreen(object sender, EventArgs e)
    {
        loseStateMenuGameObject.SetActive(true);
        _player.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
