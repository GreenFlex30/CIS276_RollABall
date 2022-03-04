using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // velocity and key input
    private Vector2 moveInput;
    private Rigidbody rb;
    
    // the default speed of player
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        // Getting Rigidbody from Inspector
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // class is called for constant movement
        MovePlayer();
    }

    private void Update()
    {
        // key input is received here
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void MovePlayer()
    {
        // ensures movement for x and y directions
        Vector2 directionX = transform.right.normalized * moveInput.x * speed;
        Vector2 directionY = transform.forward.normalized * moveInput.y * speed;

        rb.velocity = new Vector2(0, 0) + (directionX + directionY);
    }
}
