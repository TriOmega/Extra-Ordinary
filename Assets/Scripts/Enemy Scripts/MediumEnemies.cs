using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MediumEnemies : MonoBehaviour, IDamageable, IStunnable
{
    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }
    public bool IsStunned { get => isStunned; }
    public float StunDurationSeconds { get => stunDurationSeconds; }

    private bool activeEnemyShield;
    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;
    public GameObject tempStunIndicatorObject;              //Remove temp indicator as soon as official stun indication is added
    //public GameObject EnemyShieldIndicator;  //HEY SHERRYE i made this pink shield for the rolliepollie just to help myself out while testing.
    // Its just a visual indicator of weather or not the shield is broken or not. Feel free to delete. 

    public Animator animator;
    private bool isBouncing = false;

    public ParticleSystem poof;
    
    // Start is called before the first frame update
    void Start()
    {
        activeEnemyShield = true;
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(activeEnemyShield == true)
        //{
            //EnemyShieldIndicator.SetActive(true);
        //}
        //else
        //{
            //EnemyShieldIndicator.SetActive(false);
        //}
    }

    public void BreakShield()                           
    {
        activeEnemyShield = false;
        animator.SetTrigger("isBroken");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ForceField")
        {
            BreakShield();
        }     
    }

    public void TakeDamage(int damageAmount)
    {
        if(activeEnemyShield == false)                       
        {
            enemyHealth -= damageAmount;
        
            if(enemyHealth <= 0)
            {
                //Death animation + sound
                animator.SetTrigger("isKilled");
                poof.Play();
                Destroy(this.gameObject, 1);
            }

            else
            {
                animator.SetTrigger("isDamaged");
                //Damage Sound + animation if we need it
            }
        }
    }

    public void Stun()
    {
        if (!isStunned)
        {
            Instantiate(tempStunIndicatorObject, transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);
            StartCoroutine(StunTimer());
        }
    }
    private IEnumerator StunTimer()
    {
        isStunned = true;
        animator.enabled = false;
        navMeshAgent.enabled = false;

        yield return new WaitForSeconds(stunDurationSeconds);

        isStunned = false;
        animator.enabled = true;
        navMeshAgent.enabled = true;
    }

    private int enemyHealth = 100;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
    private bool isStunned = false;
    private float stunDurationSeconds = 5f;

}
     