using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{


    public float returnSpeed = 10;

    private Vector3 moveToPlayer;
    public GameObject startingPoint;

    public bool moving = false;


    public void Update()
    {
        startingPoint = GameObject.Find("BallLocation");
        if (startingPoint != null)
        {
            moveToPlayer = startingPoint.transform.position;
        }
        else
        {
            Debug.Log("Starting Point \"BallLocation\" could not be found.");
        }


        if (moving)
        {
            float step = returnSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveToPlayer, step);
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            moving = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            moving = false;
        }

    }
}
