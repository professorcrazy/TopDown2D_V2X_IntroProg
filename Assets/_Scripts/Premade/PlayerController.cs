using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Premade { 
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb;
        public float speed = 5f;
        Vector2 move;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move() {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            move = move.normalized * speed;
            rb.velocity = move;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("hit");
        }
    }
}
