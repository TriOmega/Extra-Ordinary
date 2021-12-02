using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointHandler : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _levelStart;

    public float checkpointTextDuration = 3.0f;
    public Text checkpointText;
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
        if(LastCheckpoint == null)
        {
            ResetToLevelStart();
        }
        else
        {
            _player.GetComponent<CharacterController>().enabled = false;
            _player.transform.SetPositionAndRotation(LastCheckpoint.transform.position, Quaternion.identity);
            _player.GetComponent<CharacterController>().enabled = true;
        }
    }

    public void PopUpCheckpointText()
    {
        checkpointText.enabled = true;
        Invoke("DeactivateCheckpointText", checkpointTextDuration);
    }

    public void DeactivateCheckpointText()
    {
        checkpointText.enabled = false;
    }
}
