using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandardEnemies : MonoBehaviour, IDamageable, IStunnable
{
    public int Health { get => enemyHealth; set => enemyHealth = value; }
    public bool IsInvincible { get => isInvincible; }
    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }
    public bool IsStunned { get => isStunned; }
    public float StunDurationSeconds { get => stunDurationSeconds; }

    public Animator animator;
    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
         if (isInvincible) return;

        Health -= damageAmount;
        

        if (!isInvincible)
        {
            StartCoroutine(BeginInvincibility());
        }

        if(enemyHealth <= 0)
        {
            //Death animation + sound
            animator.SetTrigger("isKilled");
            Destroy(this.gameObject, 1);
        }
        else
        {
            animator.SetTrigger("isDamaged");
            gameObject.GetComponent<ParticleSystem>().Play();
            //Damage Sound + animation if we need it
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

    public int enemyHealth = 40;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
    private bool isStunned = false;
    private float stunDurationSeconds = 5f;
}
