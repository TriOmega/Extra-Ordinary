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
     
     void Start () 
     {
         tempVal = transform.position.y;
         tempPos = transform.position;
     }
 
     void Update () 
     {        
         tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
         transform.position = tempPos;
     }

    public override void PickUpEffect(GameObject player)
    {
        player.GetComponent<PlayerHealth>().AdjustCurrentLives(pickUpLifeWorth);
    }
}
