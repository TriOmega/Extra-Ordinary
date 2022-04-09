using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMirror : MonoBehaviour
{
    [SerializeField, Tooltip("Put reference to a door's key that is hidden out of bounds here.")]
    private GameObject key;
    [SerializeField]
    private bool isKeyMirror = false;

    [SerializeField]
    private List<ReflectingMirror> reflectingMirrors = new List<ReflectingMirror>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight") && isKeyMirror)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            key.transform.position = transform.position + transform.forward;
        }
    }
}
