using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemies : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPosition = GetComponent<Transform>().position;
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
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
}
