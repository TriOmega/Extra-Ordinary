using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private Transform thisCheckpointRespawn;

    CheckpointTrigger()
    {
        thisCheckpointRespawn = this.GetComponentInParent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CheckpointHandler>().LastCheckpoint = thisCheckpointRespawn;
    }
}
