using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReactions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "GhostPoint")
        {

            collision.GetComponent<SpecialHHEnemy>().TakeDamage(10);
        }

    }

}
