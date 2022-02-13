using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.gameObject.name} Pressed!");
        this.gameObject.transform.Find("ButtonPressable").gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{this.gameObject.name} Released!");
        this.gameObject.transform.Find("ButtonPressable").gameObject.SetActive(true);
    }
}
