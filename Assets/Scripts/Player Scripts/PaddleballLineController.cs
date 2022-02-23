using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PaddleballLineController: MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    //public Transform RubberBallLocation;


    private void Awake()
    {
        //RubberBallLocation = GameObject.FindWithTag("ball").transform;
        lr = GetComponent<LineRenderer>();
    }
   

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }


    void Update()
    {
        //points[1] = RubberBallLocation;
        for(int i=0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }

    }
}
