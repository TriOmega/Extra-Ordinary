using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingIntoFloorPuzzle : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    GameObject breakingFloor;
    [SerializeField]
    GameObject brokenFloor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DropCrashingObject()
    {
        rb.useGravity = true;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (breakingFloor != null && collision.gameObject == breakingFloor)
        {
            Destroy(breakingFloor);
            Instantiate(brokenFloor, breakingFloor.transform.position, breakingFloor.transform.rotation);
            this.GetComponent<DestroySelf>().enabled = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
