using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionEffect;


    Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);  //makes the explosion grow

    void Start()
    {
        Destroy(explosionEffect, 0.09f);
    }

    void Update()
    {
        explosionEffect.transform.localScale += scaleChange;
    }


}
