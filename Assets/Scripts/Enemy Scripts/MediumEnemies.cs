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

    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;
    public GameObject tempStunIndicatorObject;              //Remove temp indicator as soon as official stun indication is added

    public Animator animator;
    private AudioSource pillbugAudioSource;
    public AudioClip enemyHitSFX;
    public AudioClip enemyDeathSFX;
    public ParticleSystem poof;
    [SerializeField]
    private float rushSpeed = 8f;
    [SerializeField]
    private float slowedSpeed = 2f;
    [SerializeField]
    private float slowedTimerDuration = 2f;

    void Start()
    {
        pillbugAudioSource = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = rushSpeed;
    }

    public void BreakShield()                           
    {
        animator.SetBool("isBlocking", false);
        animator.SetTrigger("isBroken");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ForceField")
        {
            BreakShield();
        }
        
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("SlowedTimer");
        }     
    }

    public void TakeDamage(int damageAmount)
    {
        if(!animator.GetBool("isBlocking"))                       
        {
            enemyHealth -= damageAmount;
        
            if(enemyHealth <= 0)
            {
                pillbugAudioSource.PlayOneShot(enemyDeathSFX);
                poof.Play();
                gameObject.GetComponent<SphereCollider>().enabled = false;
                Transform pillbugBody = gameObject.transform.Find("PillbugBody");
                pillbugBody.gameObject.SetActive(false);
                Destroy(this.gameObject, 1);
            }
            else
            {
                pillbugAudioSource.PlayOneShot(enemyHitSFX);
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

    private IEnumerator SlowedTimer()
    {
        navMeshAgent.speed = slowedSpeed;
        yield return new WaitForSecondsRealtime(slowedTimerDuration);
        navMeshAgent.speed = rushSpeed;
    }

    private int enemyHealth = 100;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 2;
    private bool isStunned = false;
    private float stunDurationSeconds = 5f;

}
     