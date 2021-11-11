using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    private GameObject _player
    {
        get => _player;
        set
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private Transform _levelStart
    {
        get => _levelStart;
        set
        {
            _levelStart = _player.transform;
        }
    }

    void Update()
    {
        Debug.Log(_player);
    }

    public void ResetToLevelStart()
    {
        //_player.transform = _levelStart;
    }

}
