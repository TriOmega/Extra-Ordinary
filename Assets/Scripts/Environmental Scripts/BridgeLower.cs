using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLower : MonoBehaviour
{
    [SerializeField, Tooltip("Place bridge pivot object here.")]
    private Transform pivotTransform;
    [Tooltip("Rotate speed in degrees per second.")]
    public float rotateSpeed = 55f;
    private float rotationProgress = 0;
    [Tooltip ("The goal angle you want the bridge to turn.")]
    public float rotationGoal = 55f;

    private void Awake()
    {
        this.enabled = false;
    }

    private void Update()
    {
        if (rotationProgress < rotationGoal)
        {
            rotationProgress += rotateSpeed * Time.deltaTime;
            transform.RotateAround(pivotTransform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        else
        {
            this.enabled = false;
        }
    }
}
