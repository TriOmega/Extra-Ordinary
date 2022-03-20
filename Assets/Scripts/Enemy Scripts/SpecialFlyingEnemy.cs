using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpecialFlyingEnemy : MonoBehaviour
{
    public Animator animator;
    public float enemySpeed;
    
    public Transform ground;

    private Vector3 moveToGround;
    public GameObject startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground").transform;
        startingPoint = GameObject.Find("BallLocation");
    }

    // Update is called once per frame
    void Update()
    {

    }

     private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToGround, enemySpeed);
            transform.Rotate(0, 0, 0);
            enemySpeed = 0f;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //Death animation + sound
            //animator.SetTrigger("isKilled");
            Destroy(this.gameObject, 1);
        }

    }
    

}
