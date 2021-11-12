using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private Transform thisCheckpointRespawn;

    private void Awake()
    {
        thisCheckpointRespawn = this.GetComponentInParent<Transform>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CheckpointHandler>().LastCheckpoint = thisCheckpointRespawn;
    }
}
