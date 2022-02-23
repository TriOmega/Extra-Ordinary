using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : PickUps
{
    public int pickUpLifeWorth = 1;

    public float amplitude;          
    public float speed;                   
    private float tempVal;
    private Vector3 tempPos;
    public bool isFloating = true;
    public GameObject player;
     
     void Start () 
     {
         tempVal = transform.position.y;
         tempPos = transform.position;
     }
 
     void FixedUpdate () 
     {        
         if(isFloating)
         {
             tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
             transform.position = tempPos;
         }
        
     }

     private void OnTriggerEnter(Collider collision)
     {
        if (collision.gameObject.tag == "ball")
        {
            isFloating = false;
        }

        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().AdjustCurrentLives(pickUpLifeWorth);
            Destroy(gameObject);
        }

     }

     //public override void PickUpEffect(GameObject player)  -- Had to move this up
     //{
      //  player.GetComponent<PlayerHealth>().AdjustCurrentLives(pickUpLifeWorth);
    // }
}