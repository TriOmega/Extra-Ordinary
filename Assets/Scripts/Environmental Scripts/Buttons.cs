using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ButtonEvent : UnityEvent { }

public class Buttons : MonoBehaviour
{
    public ButtonEvent ButtonPressed;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log($"{this.gameObject.name} Pressed!");
            this.gameObject.transform.Find("ButtonPressable").gameObject.SetActive(false);
            ButtonPressed?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{this.gameObject.name} Released!");
        this.gameObject.transform.Find("ButtonPressable").gameObject.SetActive(true);
    }
}
