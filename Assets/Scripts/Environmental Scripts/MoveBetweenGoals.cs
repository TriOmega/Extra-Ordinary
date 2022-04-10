using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenGoals : MonoBehaviour
{
    [SerializeField]
    private Transform goal1;
    [SerializeField]
    private Transform goal2;
    private Vector3 directionToGoal1;
    private Vector3 directionToGoal2;
    private float fractionOfDistance = .5f;

    private void Start()
    {
        transform.position = Vector3.Lerp(goal1.position, goal2.position, 0);
        directionToGoal1 = transform.position - goal1.position;
        directionToGoal2 = transform.position - goal2.position;
    }

    public void MoveTowardsGoal1()
    {
        fractionOfDistance -= Time.deltaTime;
        transform.position = Vector3.Lerp(goal1.position, goal2.position, fractionOfDistance);
    }

    public void MoveTowardsGoal2()
    {
        fractionOfDistance += Time.deltaTime;
        transform.position = Vector3.Lerp(goal1.position, goal2.position, fractionOfDistance);
    }

}
