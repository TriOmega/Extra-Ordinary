using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBombToPlayer : MonoBehaviour
{

    public float returnSpeed = 30;
    private Vector3 moveToPlayer;
    private Vector3 throwAtBoss;
    public GameObject startingPoint;
    public GameObject bossLocation;
    public float speed = 30f;
    public bool grabbed = false;

    public bool moving = false;


    public void Start()
    {
        bossLocation = GameObject.Find("Forcefield Spawner");
        throwAtBoss = bossLocation.transform.position;
        
    }




    public void Update()
    {
        
        moveToPlayer = startingPoint.transform.position;
        


        if (moving == true)
        {
            float step = returnSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveToPlayer, step);
        }

        if (grabbed == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, throwAtBoss, step);
        }

    }


    private void OnTriggerEnter(Collider collision)
    {
        

        if (collision.gameObject.tag == "ball")
        {
            startingPoint = GameObject.Find("BallLocation");
            moving = true;
        }

        if (collision.gameObject.CompareTag ("Shockwave"))
        {
            grabbed = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = false;
            grabbed = true; 
        }

    }
}
