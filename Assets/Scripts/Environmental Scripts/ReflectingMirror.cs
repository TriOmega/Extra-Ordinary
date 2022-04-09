using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingMirror : MonoBehaviour
{
    //[SerializeField, Tooltip("Put KeyMirror that this objec"]
    //private KeyMirror keyMirrorReference;
    [SerializeField]
    private Transform reflectionBeamStartPoint;
    [SerializeField]
    private Transform reflectionBeamEndPoint;
    [SerializeField]
    private Transform reflectionBeam;

    private void Update()
    {
        float distance;
        distance = Vector3.Distance(reflectionBeamStartPoint.position, reflectionBeamEndPoint.position);
        reflectionBeam.localScale = new Vector3(reflectionBeam.localScale.x, distance/2f, reflectionBeam.localScale.z);
        Vector3 midPoint = (reflectionBeamStartPoint.position + reflectionBeamEndPoint.position) / 2f;
        reflectionBeam.position = midPoint;
        Vector3 rotationDirection = (reflectionBeamEndPoint.position - reflectionBeamStartPoint.position);
        reflectionBeam.up = rotationDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {

        }
    }
}
