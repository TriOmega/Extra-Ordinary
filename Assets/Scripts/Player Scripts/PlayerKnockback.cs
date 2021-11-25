using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    float mass = 3.0f; // defines the character mass
    Vector3 impact = Vector3.zero;
    CharacterController character;



    void Start ()
    {
        character = GetComponent<CharacterController>();
    }
        
    void Update ()
    {
        if (impact.magnitude > 0.2f) 
        {
            character.Move(impact * Time.deltaTime);  //Applies the impact force
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime); //consumes the impact energy each cycle
        }


    }
    



    public void AddImpact(Vector3 dir, float force) // call this function to add an impact force
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }


}
