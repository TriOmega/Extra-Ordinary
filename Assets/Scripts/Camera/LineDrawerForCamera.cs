using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerForCamera : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private PaddleballLineController line;

    private void Start()
    {
        line.SetUpLine(points);
    }
}
