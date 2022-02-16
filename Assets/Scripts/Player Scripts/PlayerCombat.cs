using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Collider playerBasicAttackBox;
    public Collider bubblegumAttackBox;
    public LayerMask basicEnemyLayer;
    public float swordKnockbackThrust = 8.0f;
    public float bubblegumKnockbackThrust = 10.0f;
    public float attackStartTime;
    public float timeToActivateHeavy = 1.0f;
    private bool attackPressed = false;
    [SerializeField]
    private int heavyDamageMultiplier = 2;
    [SerializeField]
    private int lightAttackDamage = 20;
    [HideInInspector]
    public int damageAmount;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.Log("Debug Activated");
        }

        if (Input.GetAxis("BasicAttack") == 1 && !attackPressed)
        {
            damageAmount = lightAttackDamage;
            attackStartTime = Time.time;
            anim.SetTrigger("Sword");
            attackPressed = true;
            StartCoroutine(HeavyAttack());
        }
        else if (Input.GetAxis("BasicAttack") == 0)
        {
            attackPressed = false;
        }

        if (BubbleGum.AttackCanGo == true)
        {
            BubbleGum.AttackCanGo = false;
        }
    }

    private IEnumerator HeavyAttack()
    {
        while (attackPressed)
        {
            if (Time.time > attackStartTime + timeToActivateHeavy)
            {
                damageAmount = damageAmount * heavyDamageMultiplier;
                anim.SetTrigger("Sword");
                gameObject.GetComponent<ParticleSystem>().Play();
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void ToggleSwordHitBox (int eventResult)
    {
        switch (eventResult)
        {
            case 0:
                playerBasicAttackBox.enabled = false; 
                break;
            case 1:
                playerBasicAttackBox.enabled = true; 
                break;
        }
    }

    private void BubblegumAttack(Collider bubblegumAttackBox)
    {  
    
        Collider[] cols = Physics.OverlapBox(bubblegumAttackBox.bounds.center, bubblegumAttackBox.bounds.extents, bubblegumAttackBox.transform.rotation, basicEnemyLayer);
        foreach(Collider col in cols)
        {

            Vector3 moveDirection = col.transform.position - this.transform.position;
            col.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * bubblegumKnockbackThrust);
        }
    }

/*OLD BLOCKING CODE FROM LAST SEMESTER IS BELOW:
feel free to remove if not needed. 

    private void Block()
    {
        Transform targetTransform = (Blocking.projectileTransform == null) ? playerBasicAttackBox.transform : Blocking.projectileTransform;
        Vector3 tempPosition = targetTransform.position;
        tempPosition.y = this.transform.position.y;
        targetTransform.position = tempPosition;
        //Debug.Log(targetTransform);
        this.transform.LookAt(targetTransform);
    }
     Block() Flaws: 1. Adjusts target transform too (if projectiles get destroyed on block anyways we might not need to worry)
                             2. Transform doesn't get reset after blocking ends, possible fix is to figure out how to implement OnTriggerEnter for the PlayerCombat script*/
}
