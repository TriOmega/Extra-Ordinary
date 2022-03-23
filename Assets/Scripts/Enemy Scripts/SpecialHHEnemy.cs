using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialHHEnemy : MonoBehaviour, IDamageable
{
    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    public Animator animator;
    public ParticleSystem burn;
    public ParticleSystem poof;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
         if (isInvincible) return;

        Health -= damageAmount;
        Debug.Log("Ghost is taking damage");

        if (!isInvincible)
        {
            StartCoroutine(BeginInvincibility());
        }

        if(enemyHealth <= 0)
        {
            //Death animation + sound
            animator.SetTrigger("isKilled");
            poof.Play();
            Destroy(this.gameObject, 1);
        }
        else
        {
            //animator.SetTrigger("isDamaged");
            burn.Play();
            //Damage Sound + animation if we need it
        }
    }

    private IEnumerator BeginInvincibility()
    {
        isInvincible = true;
        
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        
        isInvincible = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Flashlight"))
        {
            TakeDamage(10);
        }
    }

    public int enemyHealth = 50;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
}


