using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldRotator : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        yAngle = 90.0f;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void WorldRotation()
    {
        //transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);

        transform.RotateAround(target.transform.position, Vector3.up, 10);
    }
}
