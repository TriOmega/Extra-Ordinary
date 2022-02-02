using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScorpionEnemy : MonoBehaviour
{
    //lots of slashes sorry ignore them

   // private string State = "Idle";
    //for animation
    //public NavMeshAgent Enemy;
    //private Transform target;
    //public float spaceDifference = 5;
   // public float attackSpace = 1;
    //public float speed = 5; 
   // public int health;
    //public int maxHealth;

    public GameObject player;
    private Transform playerPosition;
    private Vector3 currentPosition;
    public float distanceFromPlayer;
    public float enemySpeed;
    public int health;
    public int maxHealth;
     
    // Start is called before the first frame update
    void Start()
    {
       // target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
        //Enemy = GetComponent<NavMeshAgent>();
        playerPosition = player.GetComponent<Transform>();
        currentPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
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
    
         //float distance = Vector3.Distance(transform.position, target.position);
         

        //if(CharController.gameOver)
        //{
            //aesthetic choices here
        //}

        //if(State == "Idle")
           // {
             //  if(distance < spaceDifference)
              //  {
              //     State = "Chase";
               // }
           // }
       // else if(State == "Chase")
      //  {
            //animation would go here
         //   Enemy.SetDestination(target.position);

         //  if(distance < attackSpace)
         //   {
          //    State = "Attack";
          //  }
            
          //  else if(State == "Attack")
          //  {
            //      if(distance > attackSpace)
             //       {
               //         State = "Chase";
                //    }
          //  }

       // }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Sword") && PlayerCombat.isSwordSwinging == true)
        {
            //State = "Chase";
            health --;
            
            
            if(health <= 0)
            {
                Debug.Log("DEFEAT HAS HAPPENED <3");
                Destroy(this.gameObject, 1);
            }
            
            PlayerCombat.isSwordSwinging = false;
        }
    }
}
