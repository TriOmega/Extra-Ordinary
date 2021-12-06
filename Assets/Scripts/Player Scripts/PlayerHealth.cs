using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 10;
    public int maxLives = 3;
    public int currentLives;

    public float defaultEnemyDamage = -1.0f;

    //public float regeneration = 0.5f;

    public float damageTimer = 1f;
    private bool canTakeDamage = true;

    public Text livesText;
    private CheckpointHandler checkpointHandler;
    
    private GameObject bodyLight;
    private Light myBodyLight;
    public float lightDamage = 0.5f;

    public event EventHandler NoMoreLives;

    public void Start()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;
        checkpointHandler = GetComponent<CheckpointHandler>();
        UpdateLivesText();
        bodyLight = GameObject.Find("Point light");
        myBodyLight = bodyLight.GetComponent<Light>();
    }

    public void Update()
    {
        //Player Auto-Regen
        //if (currentHealth < maxHealth)
        //    currentHealth += regeneration * Time.deltaTime;

        if (myBodyLight.range <= 0)
            currentHealth -= lightDamage;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            AdjustCurrentHealth(defaultEnemyDamage);
            //  StartCoroutine(damageTimeout(damageTimer));
        }

        if (collision.gameObject.tag == "puddles")
        {
            AdjustCurrentHealth(-5);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Shockwave") || other.CompareTag ("Explosion"))
        {
            AdjustCurrentHealth(-10);
        }

        if(other.CompareTag("Web"))
        {
           AdjustCurrentHealth(-5); 
        }
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
        if (currentHealth <= 0)
        {
            LoseLife();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }

    public void AdjustCurrentLives(int adjustment)
    {
        currentLives += adjustment;
        if (adjustment < 0)
        {
            LoseLife();
            return;
        }
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }
        if (maxLives < 1)
        {
            maxLives = 1;
        }
        UpdateLivesText();
    }
    

    public void UpdateLivesText()
    {
        livesText.text = $"{currentLives}";
    }

    public void LoseLife()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            NoMoreLives?.Invoke(this, EventArgs.Empty);
            //checkpointHandler.ResetToLevelStart();
            //currentLives = maxLives;
        }
        else
        {
            checkpointHandler.ResetToLastCheckpoint();
            currentHealth = maxHealth;
        }

        UpdateLivesText();
        currentHealth = maxHealth;
    }
}
