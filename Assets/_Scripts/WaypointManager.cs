using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GetComponentsInChildren<Transform>();
    }
}
