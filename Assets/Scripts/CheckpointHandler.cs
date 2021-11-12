using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    private GameObject _player;
    private Transform _levelStart
    {
        get => _levelStart;
        set
        {
            _levelStart = _player.transform;
        }
    }
    public Transform LastCheckpoint;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ResetToLevelStart()
    {
        _player.transform.SetPositionAndRotation(_levelStart.transform.position, Quaternion.identity);
    }

    public void ResetToLastCheckpoint()
    {
        _player.GetComponent<CharacterController>().enabled = false;
        _player.transform.SetPositionAndRotation(LastCheckpoint.transform.position, Quaternion.identity);
        _player.GetComponent<CharacterController>().enabled = true;
    }
}
