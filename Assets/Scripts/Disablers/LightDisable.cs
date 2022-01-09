using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDisable : MonoBehaviour
{
    public GameObject Flashlight;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Flashlight.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Flashlight.SetActive(true);
        }
    }
}
