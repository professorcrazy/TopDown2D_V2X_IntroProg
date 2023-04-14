using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 4;
    public WaypointManager wpManager;
    int nextWPIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = wpManager.waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {

        Vector2 dir = wpManager.waypoints[nextWPIndex].position - transform.position;
        if (dir.sqrMagnitude < 0.25f) 
        {
            nextWPIndex = (nextWPIndex + 1) % wpManager.waypoints.Length;
        }
        
        dir = dir.normalized * speed;
        rb.velocity = dir;
    }
}
