using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{

    private GameObject bodyLight;
    private Light myBodyLight;

    private GameObject lightObject;
    private Light myLightComponent;

    public float lighSubtractSpeed = 0.5f;


    void Start()
    {

        bodyLight = GameObject.Find("Point light");
        myBodyLight = bodyLight.GetComponent<Light>();

        lightObject = GameObject.Find("Spot Light");
        myLightComponent = lightObject.GetComponent<Light>();
    }


    void Update()
    {
        if (!myLightComponent.enabled)
            myBodyLight.range -= lighSubtractSpeed;
        else
            myBodyLight.range = 10; 
    }
}
