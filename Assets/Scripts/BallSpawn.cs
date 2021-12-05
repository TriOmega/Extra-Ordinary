using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{

    public GameObject ball;

    [SerializeField]
    private float lookTurnSpeed = 180.0f;

    void OnEnable()
    {
        spawnBall();
    }

    public void spawnBall()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }

    private void Update()
    {
        float verticalInputDirection = Input.GetAxis("VerticalLookDirection");
        //Debug.Log(verticalInputDirection);

        if (verticalInputDirection != 0)
        {
            transform.Rotate(Vector3.left, verticalInputDirection * lookTurnSpeed * Time.deltaTime, Space.Self);            //Possible future bug: dependency on Time.deltaTime could cause strange results on slower computers
        }
    }
}
