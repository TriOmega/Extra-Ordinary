using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{

    public GameObject bomb;
    Rigidbody bombRigidbody;
    public Transform explosionSpawner;
    public GameObject explosionSphere;
    public GameObject WhiteColorSphere;


    float timeRemaining = 10f;

    void Start()
    {
        bombRigidbody = bomb.GetComponent<Rigidbody>();
        bombRigidbody.AddForce(0, 300, -80000 * Time.deltaTime);
    }


    void Update()
    {
        
        timeRemaining -= Time.deltaTime;




        if((timeRemaining < 8f) && (timeRemaining > 7.85f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 6f) && (timeRemaining > 5.85f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 5f) && (timeRemaining > 4.85f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 4f) && (timeRemaining > 3.85f))
        {
            WhiteColorSphere.SetActive(true);
        }
            if((timeRemaining < 4.5f) && (timeRemaining > 4.4f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 3.5f) && (timeRemaining > 3.4f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 3f) && (timeRemaining > 2.9f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 2.5f) && (timeRemaining > 2.4f))
        {
            WhiteColorSphere.SetActive(true);
        }
            else if((timeRemaining < 2.25f) && (timeRemaining > 2.15f))
        {
            WhiteColorSphere.SetActive(true);
        }
            if((timeRemaining < 2f) && (timeRemaining > 1.9f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 1.75f) && (timeRemaining > 1.65f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 1.5f) && (timeRemaining > 1.4f))
        {
            WhiteColorSphere.SetActive(true);
        }
        else if((timeRemaining < 1.25f) && (timeRemaining > 1.15f))
        {
            WhiteColorSphere.SetActive(true);
        }
            else if((timeRemaining < 1f) && (timeRemaining > 0.25f))
        {
            WhiteColorSphere.SetActive(true);
            Vector3 shockwaveLocation = new Vector3(explosionSpawner.position.x, explosionSpawner.position.y, explosionSpawner.position.z);
            Instantiate (explosionSphere, shockwaveLocation, explosionSpawner.rotation);
            timeRemaining = 0;
            Destroy(bomb, 0.1f);
        }
        else
        {
            WhiteColorSphere.SetActive(false);
        }

        
    }  




}
