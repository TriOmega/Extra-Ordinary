using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePuzzle : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = meshRenderer.materials[2];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            meshRenderer.material = meshRenderer.materials[1];
        }
    }
}
