using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public CharacterController controller;
  

    public float speed = 18f; //Speed at which the player walks around.
    public float gravity = -100.81f;
    public float defaultJumpHeight = 3f;
    private float jumpHeight;

    public Transform cameraTransform;
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
        jumpHeight = defaultJumpHeight;
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
        Vector3 direction = new Vector3(horizontal , 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward = cameraForward.normalized;
            cameraRight = cameraRight.normalized;
            Vector3 cameraRelativeDirection = cameraForward * direction.z + cameraRight * direction.x;

            float targetAngle = Mathf.Atan2(cameraRelativeDirection.x, cameraRelativeDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(cameraRelativeDirection * speed * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }


        if(isGrounded == true)
        {
            allowedToUseGum = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded == true)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                anim.SetTrigger("Jump");
            }
            else
            {
                if(allowedToUseGum == true)
                {
                    GumGameObject.transform.localScale += (Vector3.one * deployRate);  //Quickly inflate bubble
                    GumGameObject.transform.localScale += (Vector3.one * scaleRate);  //This applies the slow fluxuating size effect.
                    CharController.velocity.y = Mathf.Sqrt(gumJumpHeight * -2f * gumGravity); //Double jump activates
                    allowedToUseGum = false;
                }
            }

        }



        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); //increases fall speed over time.

        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
            Debug.Log("Game Quit!");
        }


        if(CharController.isGrounded == true)
        {
            GumGameObject.transform.localScale = new Vector3(0.0001f,0.0001f,0.0001f);  //makes the gum very very very tiny if its not in use.
        }

        //This is for the gum fluctuating size effect. If it exceeds the defined range then correct the sign of scaleRate.
        if(GumGameObject.transform.localScale.x < minScale) 
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if(GumGameObject.transform.localScale.x > maxScale) 
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }

    }

    public void PauseMovement() 
    
    {
        Debug.Log("This script was called");
        speed = 0f;
        jumpHeight = 0f;
        
    }

    public void ResumeMovement()
    {
        speed = 3f; 
        jumpHeight = defaultJumpHeight;
    }


 //////////////////////////////////BUBBLEGUM DOUBLE JUMP///////////////////////////////////////////////////////////////////////

    public GameObject GumGameObject;

    float scaleRate = 0.015f;  //How fast the bubblegum fluctuates
    float deployRate =0.5f; //How fast the bubblegum deploys initially
    float minScale = 10.0f;
    float maxScale = 10.5f;

    bool allowedToUseGum = false;

    float gumGravity = -40f;
    float gumJumpHeight = 0.7f;






























}