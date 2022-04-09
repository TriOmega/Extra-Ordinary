using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectingMirror : MonoBehaviour
{
    //[SerializeField, Tooltip("Put KeyMirror that this objec"]
    //private KeyMirror keyMirrorReference;
    [SerializeField, Tooltip("Place reflection beam pivot here. Use pivot object to aim reflection beam.")]
    private Transform reflectionBeamPivot;
    [SerializeField]
    private float reflectionBeamEndSurplus = .75f;
    private RaycastHit hit;
    private LineRenderer lineRenderer;

    private void Start()
    {
        reflectionBeamPivot.gameObject.SetActive(false);
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, reflectionBeamPivot.position);
        if (Physics.Raycast(reflectionBeamPivot.position, reflectionBeamPivot.up, out hit, Mathf.Infinity))
        {
            if (hit.collider)
            {
                lineRenderer.SetPosition(1, hit.point + (reflectionBeamPivot.up * reflectionBeamEndSurplus));
            }
        }
        else lineRenderer.SetPosition(1, reflectionBeamPivot.up * 50);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            lineRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            lineRenderer.enabled = false;
        }
    }
}
