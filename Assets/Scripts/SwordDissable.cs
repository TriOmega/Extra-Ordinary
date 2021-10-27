using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDissable : MonoBehaviour
{
    public GameObject sword;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sword.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sword.SetActive(true);
        }
    }
}
