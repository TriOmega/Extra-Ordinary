using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private Transform thisCheckpointRespawn;

    private void Awake()
    {
        thisCheckpointRespawn = transform.parent.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckpointHandler checkpointHandler = other.gameObject.GetComponent<CheckpointHandler>();
        checkpointHandler.LastCheckpoint = thisCheckpointRespawn;
        checkpointHandler.PopUpCheckpointText();
    }
}
