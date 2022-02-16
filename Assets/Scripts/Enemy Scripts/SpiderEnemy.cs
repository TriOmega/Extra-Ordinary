using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public float distanceFromPlayer;
    
    private Vector3 currentPosition;
    

    public Transform player;
    public GameObject web;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private Vector3 moveToPlayer;
    public GameObject startingPoint;

    public int health;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPosition = GetComponent<Transform>().position;
        timeBetweenShots = startTimeBetweenShots;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
            startingPoint = GameObject.Find("BallLocation");
            moveToPlayer = startingPoint.transform.position;

         if(Vector3.Distance(transform.position, player.position) < distanceFromPlayer)
        {
             if(Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
              transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
            }

            else if(Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }

            else if(Vector3.Distance(transform.position, player.position) < retreatDistance)
            {
             transform.position = Vector3.MoveTowards(transform.position, player.position, -enemySpeed * Time.deltaTime);
            }

            if(timeBetweenShots <- 0)
            {
                Instantiate(web, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }

            else
            {
                timeBetweenShots -= Time.deltaTime;
            }


        }

        else
        {
            if(Vector3.Distance(transform.position, currentPosition) <= 0)
            {

            } 
        
        }
    }

     private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPlayer, enemySpeed);
            transform.Rotate(0, 0, 0);
            enemySpeed = 0f;
        }

        if(collision.CompareTag("Sword"))
        {
            health --;
            
            
            if(health <= 0)
            {
                Debug.Log("Death <3");
                Destroy(this.gameObject, 1);
            }
            
        }

    }
    

}
