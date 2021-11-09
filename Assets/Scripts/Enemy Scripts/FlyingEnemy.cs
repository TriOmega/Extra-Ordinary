using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject player;
    private Transform playerPosition;
    private Vector3 currentPosition;
    public float distanceFromPlayer;
    public float enemySpeed;
    public int health;
    public int maxHealth;

    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        currentPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, playerPosition.position) < distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, enemySpeed * Time.deltaTime);
        }

        else
        {
            if(Vector3.Distance(transform.position, currentPosition) <= 0)
            {

            }
            
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentPosition, enemySpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("BubbleGum"))
        {
            health --;
            
            if(health <= 0)
            {
                Debug.Log("DEFEAT HAS HAPPENED <3");
                Destroy(this.gameObject, 1);
            }
        }
    }

}