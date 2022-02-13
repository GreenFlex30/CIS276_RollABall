using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveInput;
    private Rigidbody rb;
    private PlayerCamera playerCam;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCam = FindObjectOfType<PlayerCamera>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void MovePlayer()
    {
        transform.forward = playerCam.transform.forward;

        Vector3 directionX = transform.right.normalized * moveInput.x;
        Vector3 directionZ = transform.forward.normalized * moveInput.z;

        rb.velocity = new Vector3(0, rb.velocity.y, 0) + (directionX + directionZ);
    }
}

