using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IDamageable
{
    public GameObject destroyedDestructible;
    public GameObject boxSpawn;
    [SerializeField]
    private bool infiniteBoxLOL = false;
    public int Health { get => destructibleHealth; set => destructibleHealth = value; }

    public bool IsInvincible { get => isInvincible; }

    public float InvincibilityDurationSeconds { get => invincibilityDurationSeconds; }

    public void TakeDamage(int damageAmount)
    {
        Instantiate(destroyedDestructible, transform.position, transform.rotation);
        if (boxSpawn != null || infiniteBoxLOL)
        {
            Instantiate(boxSpawn, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
        }
        Destroy(gameObject);
    }

    private int destructibleHealth = 1;
    private bool isInvincible = false;
    private float invincibilityDurationSeconds = 0.0f;
}
