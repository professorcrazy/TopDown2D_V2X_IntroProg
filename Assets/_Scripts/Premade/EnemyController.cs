using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Premade{
    public class EnemyController : MonoBehaviour
    {
        Rigidbody2D rb;
        public float speed = 5f;
        Vector2 move;
        int nextWaypointIndex = 1;
        public WaypointManager wpManager;
        public float rotationSpeed = 360;
        public bool returnOnSamePath = false;
        int pathDirection = 1;
        // Start is called before the first frame update
        void Start() {
            rb = GetComponent<Rigidbody2D>();
            transform.position = wpManager.waypoints[0].position;
        }

        // Update is called once per frame
        void Update() {
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
            if (returnOnSamePath) {
                MoveWithReturn();
            }
            else {
                Move();
            }
        }

        void Move() {
            Vector2 dir = wpManager.waypoints[nextWaypointIndex].position - transform.position;
            if (dir.sqrMagnitude < 0.25f) {
                nextWaypointIndex = (nextWaypointIndex + 1) % wpManager.waypoints.Length;
            }
            else {
                rb.velocity = dir.normalized * speed;
            }
        }
        void MoveWithReturn() {

            Vector2 dir = wpManager.waypoints[nextWaypointIndex].position - transform.position;
            if (dir.sqrMagnitude < 0.25f) {
                if (nextWaypointIndex + 1 >= wpManager.waypoints.Length || nextWaypointIndex - 1 < 0) {
                    pathDirection *= -1;
                }
                nextWaypointIndex = (nextWaypointIndex + pathDirection);
            }
            else {
                rb.velocity = dir.normalized * speed;
            }
        }
    }
}
