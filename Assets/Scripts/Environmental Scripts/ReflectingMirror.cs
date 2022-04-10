using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingMirror : MonoBehaviour
{
    [SerializeField]
    private int mirrorIndex = 99;
    [SerializeField, Tooltip("Put KeyMirror that this object has as a goal here.")]
    private KeyMirror keyMirrorReference;
    [SerializeField, Tooltip("Place reflection beam pivot here. Use pivot object to aim reflection beam.")]
    private Transform reflectionBeamPivot;
    [SerializeField, Tooltip("Place reflection beam trigger here.")]
    private Transform reflectionBeamTrigger;
    [SerializeField, Tooltip("Adjust this to change how far the reflection beam goes into objects once it has collided.")]
    private float reflectionBeamEndSurplus = .75f;
    private RaycastHit hit;
    private LineRenderer lineRenderer;

    private void Start()
    {
        for(int i = 0; i < keyMirrorReference.reflectingMirrors.Count; i++)
        {
            if(this == keyMirrorReference.reflectingMirrors[i])
            {
                mirrorIndex = i;
            }
        }
        if (mirrorIndex > keyMirrorReference.reflectingMirrors.Count)
        {
            Debug.LogError($"{this.gameObject.name} has an out of bounds mirrorNumber.");
        }
        reflectionBeamPivot.gameObject.SetActive(false);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, reflectionBeamPivot.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this == keyMirrorReference.reflectingMirrors[keyMirrorReference.reflectingMirrors.Count - 1])
        {
            if (other.CompareTag("Flashlight"))
            {
                lineRenderer.enabled = true;
                CreateReflectionBeam();
            }
        }
        else if (other.transform.parent.GetComponent<ReflectingMirror>() == keyMirrorReference.reflectingMirrors[mirrorIndex + 1])
        {
            lineRenderer.enabled = true;
            CreateReflectionBeam();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this == keyMirrorReference.reflectingMirrors[keyMirrorReference.reflectingMirrors.Count - 1])
        {
            if (other.CompareTag("Flashlight"))
            {
                lineRenderer.enabled = false;
                reflectionBeamTrigger.position = reflectionBeamPivot.position;
            }
        }
        if (other.transform.parent.GetComponent<ReflectingMirror>() == keyMirrorReference.reflectingMirrors[mirrorIndex + 1])
        {
            lineRenderer.enabled = false;
            reflectionBeamTrigger.position = reflectionBeamPivot.position;
        }
    }

    private void CreateReflectionBeam()
    {
        if (Physics.Raycast(reflectionBeamPivot.position, reflectionBeamPivot.up, out hit, Mathf.Infinity))
        {
            if (hit.collider)
            {
                reflectionBeamTrigger.position = hit.point;
                lineRenderer.SetPosition(1, hit.point + (reflectionBeamPivot.up * reflectionBeamEndSurplus));
            }
        }
        else lineRenderer.SetPosition(1, reflectionBeamPivot.up * 50);
    }
}
