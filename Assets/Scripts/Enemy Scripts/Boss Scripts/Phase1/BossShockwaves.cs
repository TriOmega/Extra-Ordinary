using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShockwaves : MonoBehaviour
{
    public GameObject Shockwave;
    public GameObject Sphere;
    float lifetime = 8;
    Vector3 scaleChange = new Vector3(0.2f, 0.001f, 0.2f);

    void Start()
    {
        Destroy(Shockwave, lifetime);
        Destroy(Sphere, 0.1f);
    }

    void Update()
    {
        Shockwave.transform.localScale += scaleChange;
    }
}
