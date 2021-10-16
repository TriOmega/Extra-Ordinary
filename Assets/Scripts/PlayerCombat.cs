using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour

{
    public GameObject swordPivot;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            swordPivot.GetComponent<Animator>().Play("sword_slash");
        }
    }
}
