using UnityEngine;
using System;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseStateMenuGameObject;
    private PlayerHealth _playerHealth;

    public void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        loseStateMenuGameObject.SetActive(false);
        _playerHealth.NoMoreLives += LoseScreen;
    }

    public void LoseScreen(object sender, EventArgs e)
    {
        loseStateMenuGameObject.SetActive(true);
    }
}
