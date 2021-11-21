using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFollow : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    private GameObject lightObject;
    private Light myLightComponent;
  

    private void Start()
    {
        lightObject = GameObject.Find("Spot Light");
        myLightComponent = lightObject.GetComponent<Light>();
    }

    void Update()
    {   
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
            transform.LookAt(hit.point);
        }

        if (Input.GetKeyUp(KeyCode.F))
            myLightComponent.enabled = !myLightComponent.enabled;
    } 
}