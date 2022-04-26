using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointRefs : MonoBehaviour
{
    [SerializeField]
    public List<Transform> waypoints = new List<Transform>();

    private void Start()
    {
        foreach(Transform waypoint in waypoints)
        {
            waypoint.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
