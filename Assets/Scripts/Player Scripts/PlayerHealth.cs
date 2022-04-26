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

    [SerializeField]
    private float invincibilityTime = 1f;
    private bool canTakeDamage = true;

    public Text livesText;
    private CheckpointHandler checkpointHandler;
    
    private GameObject bodyLight;
    private Light myBodyLight;
    public float lightDamage = 0.5f;

    public event EventHandler NoMoreLives;//

    Image NewHealthbarUI100;
    Image NewHealthbarUI80;
    Image NewHealthbarUI60;
    Image NewHealthbarUI40;
    Image NewHealthbarUI20;
    Image NewHealthbarUI0;




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


        NewHealthbarUI100 = GameObject.Find("UI_Healthbar100_01").GetComponent<Image>();
        NewHealthbarUI80 = GameObject.Find("UI_Healthbar80_01").GetComponent<Image>();
        NewHealthbarUI60 = GameObject.Find("UI_Healthbar60_01").GetComponent<Image>();
        NewHealthbarUI40 = GameObject.Find("UI_Healthbar40_01").GetComponent<Image>();
        NewHealthbarUI20 = GameObject.Find("UI_Healthbar20_01").GetComponent<Image>();
        NewHealthbarUI0 = GameObject.Find("UI_Healthbar0_01").GetComponent<Image>();

    }

    public void Update()
    {
        if (Input.GetAxis("SacrificeHealth") > 0)
        {
            if ((currentHealth != maxHealth) && canSacrifice && (currentLives > 1))
            {
                LoseLife(true);
            }
        }

        if(currentHealth >= 95)
        {
            NewHealthbarUI100.enabled = true;
            NewHealthbarUI80.enabled = false;
            NewHealthbarUI60.enabled = false;
            NewHealthbarUI40.enabled = false;
            NewHealthbarUI20.enabled = false;
            NewHealthbarUI0.enabled = false;
        }

        if((currentHealth < 94) && (currentHealth > 71))
        {
            NewHealthbarUI100.enabled = false;
            NewHealthbarUI80.enabled = true;
            NewHealthbarUI60.enabled = false;
            NewHealthbarUI40.enabled = false;
            NewHealthbarUI20.enabled = false;
            NewHealthbarUI0.enabled = false;
        }

        if((currentHealth < 70) && (currentHealth > 51))
        {
            NewHealthbarUI100.enabled = false;
            NewHealthbarUI80.enabled = false;
            NewHealthbarUI60.enabled = true;
            NewHealthbarUI40.enabled = false;
            NewHealthbarUI20.enabled = false;
            NewHealthbarUI0.enabled = false;
        }

        if((currentHealth < 50) && (currentHealth > 31))
        {
            NewHealthbarUI100.enabled = false;
            NewHealthbarUI80.enabled = false;
            NewHealthbarUI60.enabled = false;
            NewHealthbarUI40.enabled = true;
            NewHealthbarUI20.enabled = false;
            NewHealthbarUI0.enabled = false;
        }

        if((currentHealth < 30) && (currentHealth > 1))
        {
            NewHealthbarUI100.enabled = false;
            NewHealthbarUI80.enabled = false;
            NewHealthbarUI60.enabled = false;
            NewHealthbarUI40.enabled = false;
            NewHealthbarUI20.enabled = true;
            NewHealthbarUI0.enabled = false;
        }

        if(currentHealth < 1)
        {
            NewHealthbarUI100.enabled = false;
            NewHealthbarUI80.enabled = false;
            NewHealthbarUI60.enabled = false;
            NewHealthbarUI40.enabled = false;
            NewHealthbarUI20.enabled = false;
            NewHealthbarUI0.enabled = true;
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if(Blocking.isBlocking == false)
        {

             if (collision.gameObject.tag == "enemy")
            {
                    AdjustCurrentHealth(defaultEnemyDamage);
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

    private IEnumerator InvincibilityTimer()
    {
        canTakeDamage = false;

        yield return new WaitForSeconds(invincibilityTime);

        canTakeDamage = true;
    }

    public void AdjustCurrentHealth(float adjustment)
    {
        if (adjustment < 0 && canTakeDamage)
        {
            currentHealth += adjustment;
            JamesHasBeenInjuredSound.Play();
            StartCoroutine("InvincibilityTimer");
        }
        else if (adjustment > 0)
        {
            currentHealth += adjustment;
        }

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
            AdjustCurrentHealth(sacrificeReward);
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
