using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _levelStart;
    public Transform LastCheckpoint;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _levelStart = _player.transform.position;
    }

    public void ResetToLevelStart()
    {
        _player.GetComponent<CharacterController>().enabled = false;
        _player.transform.SetPositionAndRotation(_levelStart, Quaternion.identity);
        _player.GetComponent<CharacterController>().enabled = true;
    }

    public void ResetToLastCheckpoint()
    {
        _player.GetComponent<CharacterController>().enabled = false;
        _player.transform.SetPositionAndRotation(LastCheckpoint.transform.position, Quaternion.identity);
        _player.GetComponent<CharacterController>().enabled = true;
    }
}
