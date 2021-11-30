using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    //public Vector3 projectilePosition = new Vector3(0.0f, 0.0f, 0.0f);
    public static Transform projectileTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
           projectileTransform = other.gameObject.transform;
            //tempPosition.y = 0.0f;
            //projectilePosition = other.bounds.center;
            Debug.Log(other.name + " is at " + other.bounds.center);
        }
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f, basicEnemyLayer))
        //{
        //    Debug.Log(hit.collider.gameObject.name + " Point of contact: " + hit.point);
        //}
    }
}
