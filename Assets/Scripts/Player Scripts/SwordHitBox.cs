using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(damageAmount);
        }
    }
}
