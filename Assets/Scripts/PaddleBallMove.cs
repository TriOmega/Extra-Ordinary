using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBallMove : MonoBehaviour
{
    public bool moving;
    public float speed = 10f;
    public bool canClick = true;

    Vector3 newPosition;
    private Vector3 position;
    public GameObject startingPoint;


    void Update()
    {

        position = startingPoint.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30f))
            {

                if (hit.transform != null && transform.position==position)
                {
                    newPosition = hit.point;
                    moving = true;

                }
            }
        }

        Moving();
    }

    private void Moving()
    {
        if (moving && transform.position != newPosition)
        {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, step);        
        }

        else
        {
            moving = false;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, position, step);
        }
    }
}
