using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumDissabler : MonoBehaviour
{
    public GameObject bubblegum;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bubblegum.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bubblegum.SetActive(true);
        }
    }


}
