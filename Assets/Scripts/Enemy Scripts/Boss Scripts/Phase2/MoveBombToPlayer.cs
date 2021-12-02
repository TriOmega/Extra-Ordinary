using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBombToPlayer : MonoBehaviour
{

    public float returnSpeed = 10;
    private Vector3 moveToPlayer;
    public GameObject startingPoint;
    public float speed = 10f;

    public bool moving = false;




    public void Update()
    {
        
        moveToPlayer = startingPoint.transform.position;


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
            startingPoint = GameObject.Find("BallLocation");
            moving = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = false;
            //Destroy(gameObject);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveToPlayer, step);
        }

    }
}
