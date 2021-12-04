using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public static int bossHealth = 100;
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
        if(collision.CompareTag("Sword") && PlayerCombat.swordHasSwung == true)
        {
            PlayRandomOuchSound();
            bossHealth = bossHealth - 5;
            Debug.Log("health is " +bossHealth);
            PlayerCombat.swordHasSwung = false;
            
            if(bossHealth <= 0)
            {
                //Destroy(this.gameObject, 1);
            }
        }
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
