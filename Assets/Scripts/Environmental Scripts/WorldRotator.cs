using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldRotator : MonoBehaviour
{

    public GameObject theEntireWorld;
    //public NavMeshData data;
    bool rotateRequest = false;
    public float rotateAngle = 60f;  //the angle at which the camera rotates every second
    float rotateTimeAmount;
    float timeRemaining;  //This is a timer that runs. It will tell the world to stop rotating after the number of seconds reaches a certain amount. 
    
 
    void Start()
    {
        timeRemaining = 10f;
    }

    void Update()
    {

        if((rotateRequest == true) && (timeRemaining > 6.9f))  //6.9 is th enumber of seconds the world rotates before stopping. 
        {
            timeRemaining -= Time.deltaTime;
            theEntireWorld.transform.RotateAround(gameObject.transform.position, Vector3.up, rotateAngle * Time.deltaTime);
            //NavMesh.AddNavMeshData(data, new Vector3(0, 0, 0), Quaternion.AngleAxis(90, Vector3.right * Time.deltaTime));
        }
           

    }
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            rotateRequest = true;
        }
    }




}
