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
    private Rigidbody rgdBody;

    public GameObject Flashlight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void OnTriggerStay(Collider collision)
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

             Flashlight.SetActive(false);

                if (Input.GetKeyDown(KeyCode.F))
                    {
                        Flashlight.SetActive(true);
                        other.ResumeMovement();
                        DestroyGhost();
                        Debug.Log("Die!!!");
                    }
             
            }

            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
        }
    }

     void DestroyGhost()
    {
        Destroy(gameObject);
        //particle system here
    }
}
