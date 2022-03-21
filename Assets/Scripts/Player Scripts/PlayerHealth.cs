using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    //public int maxLives = 3;                                  //Commented out for now given the sacrifice health changes
    public int currentLives;

    private bool canSacrifice;
    public float sacrificeReward;
    public float sacrificeCooldownDuration;
    public Image sacrificeCooldownIndicator;
    
    public AudioSource deathMusic; 
    public AudioSource LevelBackgroundMusic;
    public AudioSource JamesHasBeenInjuredSound;

    public float defaultEnemyDamage;

    //public float regeneration = 0.5f;

    public float damageTimer = 1f;
    //private bool canTakeDamage = true;

    public Text livesText;
    private CheckpointHandler checkpointHandler;
    
    private GameObject bodyLight;
    private Light myBodyLight;
    public float lightDamage = 0.5f;

    public event EventHandler NoMoreLives;

    public void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        currentLives = 3;
        canSacrifice = true;
        sacrificeReward = 75f;
        sacrificeCooldownDuration = 5f;
        defaultEnemyDamage = -10f;
        checkpointHandler = GetComponent<CheckpointHandler>();
        UpdateLivesText();
        //Old Darkness Damage
        //bodyLight = GameObject.Find("Point light");
        //myBodyLight = bodyLight.GetComponent<Light>(); 
    }

    public void Update()
    {
        //Player Auto-Regen
        //if (currentHealth < maxHealth)
        //    currentHealth += regeneration * Time.deltaTime;

        //Old Darkness Damage
        //if (myBodyLight.range <= 0)
        //{
        //    currentHealth -= lightDamage;
        //}

        if (Input.GetAxis("SacrificeHealth") > 0)
        {
            if ((currentHealth != maxHealth) && canSacrifice && (currentLives > 1))
            {
                LoseLife(true);
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(Blocking.isBlocking == false)
        {
            if (collision.gameObject.tag == "enemy")
            {
                AdjustCurrentHealth(defaultEnemyDamage);
                JamesHasBeenInjuredSound.Play();
                //  StartCoroutine(damageTimeout(damageTimer));
            }

            if (collision.gameObject.tag == "puddles")
            {
                AdjustCurrentHealth(-5);
            }
        }

    }

    
    void OnTriggerEnter(Collider other)
    {

        if(Blocking.isBlocking == false)
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
    }

    private IEnumerator SacrificeCooldown()
    {
        canSacrifice = false;
        sacrificeCooldownIndicator.color = Color.gray;

        yield return new WaitForSeconds(sacrificeCooldownDuration);

        canSacrifice = true;
        sacrificeCooldownIndicator.color = Color.white;
    }

    //private IEnumerator damageTimeout(float timer)
    //{
    //    canTakeDamage = false;
    //    yield return new WaitForSeconds(timer);
    //    canTakeDamage = true;
    //}

    public void AdjustCurrentHealth(float adjustment)
    {
        currentHealth += adjustment;
        if (currentHealth <= 0)
        {
            LoseLife(false);
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
            LoseLife(false);
            return;
        }

        UpdateLivesText();
    }
    

    public void UpdateLivesText()
    {
        livesText.text = $"{currentLives}";
    }

    public void LoseLife(bool isSacrifice)
    {
        currentLives--;

        if (currentLives <= 0)
        {
            LevelBackgroundMusic.Pause();
            deathMusic.Play();
            NoMoreLives?.Invoke(this, EventArgs.Empty);
            //checkpointHandler.ResetToLevelStart();
            //currentLives = maxLives;
        } 
        else if (isSacrifice)
        {
            currentHealth += sacrificeReward;
            StartCoroutine(SacrificeCooldown());
        }
        else
        {
            checkpointHandler.ResetToLastCheckpoint();
            currentHealth = maxHealth;
        }

        UpdateLivesText();
    }
}
