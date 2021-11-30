using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{

    public GameObject ball;


    void OnEnable()
    {
        spawnBall();
    }

    public void spawnBall()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }
}
