using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordHitBox : MonoBehaviour
{
    private GameObject player;
    private PlayerCombat combatReference;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        combatReference = player.GetComponent<PlayerCombat>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
           hit.TakeDamage(combatReference.damageAmount);
        }
    }
}
