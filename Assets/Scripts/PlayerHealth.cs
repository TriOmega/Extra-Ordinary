using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 10;
    public int maxLives = 3;
    public int currentLives;

    public float defaultEnemyDamage = -1.0f;

    public float regeneration = 0.5f;

    public float damageTimer = 1f;
    private bool canTakeDamage = true;

    public Text livesText;
    private CheckpointHandler checkpointHandler;

    PlayerHealth()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            AdjustCurrentHealth(defaultEnemyDamage);
            //  StartCoroutine(damageTimeout(damageTimer));
        }

        if (collision.gameObject.tag == "health" && canTakeDamage && currentHealth <= 9)
        {
            AdjustCurrentHealth(1);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;
        checkpointHandler = GetComponent<CheckpointHandler>();
        UpdateLivesText();
    }

    public void Update()
    {
        if (currentHealth < maxHealth)
            currentHealth += regeneration * Time.deltaTime;
    }

    private IEnumerator damageTimeout(float timer)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(timer);
        canTakeDamage = true;
    }


    public void AdjustCurrentHealth(float adjustment)
    {
        currentHealth += adjustment;
        if (currentHealth < 0)
            NextLife();
            //currentHealth = 0;
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
