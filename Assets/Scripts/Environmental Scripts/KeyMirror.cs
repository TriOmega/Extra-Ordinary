using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMirror : MonoBehaviour
{
    [SerializeField, Tooltip("Put reference to a door's key that is hidden out of bounds here.")]
    private GameObject key;

    [SerializeField]
    private List<ReflectingMirror> reflectingMirrors = new List<ReflectingMirror>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<ReflectingMirror>() == reflectingMirrors[0])
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            key.transform.position = transform.position + transform.forward;
        }
    }
}
