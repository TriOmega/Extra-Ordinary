using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    private float selfDestructDelay = 5.0f;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(selfDestructDelay);
        Destroy(gameObject);
    }
    //This could most likely be done a better way
}
