using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public CharacterController controller;
    public worldRotator rota;

    public float speed = 18f; //Speed at which the player walks around.
    public float gravity = -100.81f;
    public float jumpHeight = 6f;


    public float turnSmoothTime = 0.15f; //Speed at which the player turns (rotates) to face the direction he is moving in.
    public float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f; //This is the radius of a sphere that is projected from the player's feet. It checks to see if the ground is anywhere within this sphere. 
    public LayerMask groundMask; //This controls what objects the sphere should check for, so it doesn't collide with the player.
    public static bool isGrounded;
    
    public static Vector3 velocity; //This is the velocity that controls how gravity effects the player over time, increasing the speed at which he falls, etc. 

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(-vertical, 0f, horizontal).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Sword");
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger("Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); //increases fall speed over time.

        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
            Debug.Log("Game Quit!");
        }

    }

    public void PauseMovement() 
    
    {
        speed = 0f;
        jumpHeight = 0f;
        
    }

    public void ResumeMovement()
    {
        speed = 3f; 
        jumpHeight = 1.5f;
    }

    public void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Turn")
        {
            rota.WorldRotation();
        }
    }
}