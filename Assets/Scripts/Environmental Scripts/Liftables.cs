using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liftables : Movables
{
    public override void PutDownMovable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        transform.parent = null;
    }
}
