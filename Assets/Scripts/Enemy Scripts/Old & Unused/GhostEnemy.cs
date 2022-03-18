using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public GameObject[] points;
    int current = 0;
    float rotationSpeed;
    public float speed;
    float WPradius = 1;

    public CharController other;

    public GameObject Flashlight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

   /* void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {

           if (Vector3.Distance(points[current].transform.position, transform.position) < WPradius)
            {
             current++;
                //if (current >= points.Length)
                //{
                // current = 0;
                //}
             other.PauseMovement();
            }

            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
        }
    }*/

    void OnTriggerEnter(Collider collider)
    {

        if(collider.CompareTag("Player"))
        {

           if (Vector3.Distance(points[current].transform.position, transform.position) < WPradius)
            {
             current++;
                //if (current >= points.Length)
                //{
                // current = 0;
                //}
             other.PauseMovement();
            }

            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
        }

        if (collider.CompareTag("Flashlight"))
             {
                 other.ResumeMovement();
                 DestroyGhost();
             }
    }

     void DestroyGhost()
    {
        Destroy(gameObject, 1);
        //particle system here
    }
}
