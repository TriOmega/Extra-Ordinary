using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PaddleEvent : UnityEvent { }

public class PaddleEventHandler : MonoBehaviour
{
    public PaddleEvent PaddleHit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            PaddleHit?.Invoke();
        }
    }
}
