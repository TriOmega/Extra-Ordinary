using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{

    public int Health { get => bossHealth; set => bossHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }
    public bool IsStunned { get => isStunned; }
    public float StunDurationSeconds { get => stunDurationSeconds; }

    public static int bossHealth = 10;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
    private bool isStunned = false;
    private float stunDurationSeconds = 5f;
    public GameObject tempStunIndicatorObject;              
    public ParticleSystem poof;
    public ParticleSystem burn;
    public float yaxis = 1.5f;

    public AudioSource monster1;
    public AudioSource monster2;
    public AudioSource monster3;
    public AudioSource monster4;
    public AudioSource monster5;
    public AudioSource monster6;
    public AudioSource monster7;
    public AudioSource monster8;
    public AudioSource monster9;
    public AudioSource monster10;
    public AudioSource monster11;
    public AudioSource monster12;
    public AudioSource monster13;
    public AudioSource monster14;
    public AudioSource monster15;
    public AudioSource monster16;



    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Sword"))
        {
            PlayRandomOuchSound();
            TakeDamage(5);
            poof.Play();
            Debug.Log("health is " +bossHealth);
        }

        if(collision.CompareTag("Flashlight"))
        {
            PlayRandomOuchSound();
            TakeDamage(10);
            burn.Play();
            Stun();
        }
    }

    public void TakeDamage(int damageAmount)
    {
         if (isInvincible) return;

        Health -= damageAmount;
        

        if (!isInvincible)
        {
            StartCoroutine(BeginInvincibility());
        }

        if(bossHealth <= 0)
        {
            //Death animation + sound
            //animator.SetTrigger("isKilled");
            //poof.Play();
            //Destroy(this.gameObject, 1);
        }

    }

     private IEnumerator BeginInvincibility()
    {
        isInvincible = true;
        
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        
        isInvincible = false;
    }

    public void Stun()
    {
        if (!isStunned)
        {
            Instantiate(tempStunIndicatorObject, transform.position + new Vector3(0f, yaxis, 0f), Quaternion.identity);
            StartCoroutine(StunTimer());
        }
    }

    private IEnumerator StunTimer()
    {
        isStunned = true;

        yield return new WaitForSeconds(stunDurationSeconds);

        isStunned = false;

    }




    public void PlayRandomOuchSound()
    {
        var number = Random.Range(1,16); //picks a random number between 1 and 16
        if(number ==1)
        {
            monster1.Play();
        }
        if(number ==2)
        {
            monster2.Play();
        }
        if(number ==3)
        {
            monster3.Play();
        }
        if(number ==4)
        {
            monster4.Play();
        }
        if(number ==5)
        {
            monster5.Play();
        }
        if(number ==6)
        {
            monster6.Play();
        }
        if(number ==7)
        {
            monster7.Play();
        }
        if(number ==8)
        {
            monster8.Play();
        }
        if(number ==9)
        {
            monster9.Play();
        }
        if(number ==10)
        {
            monster10.Play();
        }
        if(number ==11)
        {
            monster11.Play();
        }
        if(number ==12)
        {
            monster12.Play();
        }
        if(number ==13)
        {
            monster13.Play();
        }
        if(number ==14)
        {
            monster14.Play();
        }
        if(number ==15)
        {
            monster15.Play();
        }
        if(number ==16)
        {
            monster16.Play();
        }
    }
}
