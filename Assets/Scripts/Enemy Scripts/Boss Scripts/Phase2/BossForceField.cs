using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossForceField : MonoBehaviour
{

    public GameObject forcefield;

    public void Start()
    {
        GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetBool("HitByBomb", false);
    }
 

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Explosion")
        {
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetBool("HitByBomb", true);
            Destroy(forcefield, 0.1f);
        }

        if(other.gameObject.tag == "Flashlight")
        {
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetBool("HitByBomb", true);
            Destroy(forcefield, 0.1f);
        }
    }



}
