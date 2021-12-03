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
        float verticalInput = Input.GetAxis("VerticalLookDirection");

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.name);
            transform.LookAt(hit.point);
        }

        if (Input.GetButtonDown("SpecialAttack"))
            myLightComponent.enabled = !myLightComponent.enabled;

        if (verticalInput != 0.0f)
        {
            transform.RotateAround(transform.position, Vector3.forward, verticalInput * 200 * Time.deltaTime);
        }
    } 
}