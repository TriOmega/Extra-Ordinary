using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBallMove : MonoBehaviour
{
    [SerializeField]
    private GamepadCursor gamepadCursor;

    public bool moving;
    public float speed = 10f;
    public bool canClick = true;

    public bool returned; 

    Vector3 newPosition;
    private Vector3 position;
    public GameObject startingPoint;

    public void Start()
    {
        startingPoint = GameObject.Find("BallLocation");
    }

    void Update()
    {
       if (startingPoint.active == false)
            Destroy(gameObject);

        position = startingPoint.transform.position; //ball return location
        if (transform.position == position)
            returned = true;

        if (Input.GetButtonDown("SpecialAttack"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(gamepadCursor.IsGamepadConnected == true ? gamepadCursor.CursorRectTransform.position : Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30f))
            {

                if (hit.transform != null && returned)
                {
                    newPosition = hit.point;
                    moving = true;
                    returned = false;

                }
            }

            if (Physics.Raycast(startingPoint.transform.position, startingPoint.transform.forward, out hit, 30.0f))
            {
                if (hit.transform != null && returned)
                {
                    newPosition = hit.point;
                    moving = true;
                    returned = false;

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
            transform.position = Vector3.MoveTowards(transform.position, position, step); //ball transform
        }
    }
}
