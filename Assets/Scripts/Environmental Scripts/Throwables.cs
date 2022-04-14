using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : Movables
{
    private float throwingThrust = 15f;
    public override void PutDownMovable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        transform.SetParent(null, true);
        rb.AddForce(transform.forward * throwingThrust, ForceMode.VelocityChange);
    }
}
