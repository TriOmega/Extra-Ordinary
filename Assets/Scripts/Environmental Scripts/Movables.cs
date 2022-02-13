using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movables : MonoBehaviour
{
    private GameObject movableDestination;
    private static bool isBeingMoved;
    private static bool isRecentlyMoved;
    private float movingCooldownDuration;

    private void Start()
    {
        isBeingMoved = false;
        movingCooldownDuration = 1f;
        movableDestination = GameObject.Find("MovableDestination");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entered");
        if (Input.GetAxis("Interact") == 1)
        {
            if (isBeingMoved && !isRecentlyMoved)
            {
                PutDownMovable();
                isBeingMoved = false;
                StartCoroutine(MovingCooldown());
            }
            else if (!isBeingMoved && !isRecentlyMoved)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                transform.position = movableDestination.transform.position;
                transform.parent = movableDestination.transform;
                isBeingMoved = true;
                StartCoroutine(MovingCooldown());
            }
        }
    }

    private IEnumerator MovingCooldown()
    {
        isRecentlyMoved = true;
        yield return new WaitForSeconds(movingCooldownDuration);
        isRecentlyMoved = false;
    }

    public virtual void PutDownMovable() { }
}
