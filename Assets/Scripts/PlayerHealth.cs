using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 10;
    public float maxHealth = 10;
    public float damageTaken = 1f;
    public int maxLives = 3;
    public int currentLives;

    public float regeneration = 0.5f;

    public float damageTimer = 1f;
    private bool canTakeDamage = true;

    public Text livesText;
    private CheckpointHandler checkpointHandler;

    PlayerHealth()
    {
        currentLives = maxLives;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            currentHealth -= damageTaken;
            //  StartCoroutine(damageTimeout(damageTimer));
        }

        if (collision.gameObject.tag == "health" && canTakeDamage && currentHealth <= 9)
        {
            currentHealth++;
        }
    }

    private void Start()
    {
        checkpointHandler = GetComponent<CheckpointHandler>();
        UpdateLivesText();
    }

    public void Update()
    {
        AdjustCurrentHealth(0);

        if (currentHealth < maxHealth)
            currentHealth += regeneration * Time.deltaTime;
    }

    private IEnumerator damageTimeout(float timer)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(timer);
        canTakeDamage = true;
    }


    public void AdjustCurrentHealth(int adj)
    {
        currentHealth += adj;
        if (currentHealth < 0)
            NextLife();
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
    }
    
    public void UpdateLivesText()
    {
        livesText.text = $"Lives: {currentLives}";
    }

    public void NextLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            checkpointHandler.ResetToLevelStart();
            currentLives = maxLives;
        }
        else
        {
            checkpointHandler.ResetToLastCheckpoint();
        }
        UpdateLivesText();
        currentHealth = maxHealth;
    }
}
