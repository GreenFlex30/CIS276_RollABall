using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
	// Using a character controller

	// Variables
	[SerializeField] public float speed = 5f;
	private float gravityComponent;
	[SerializeField] private float jumpHeight = 2f;
	[SerializeField] private float gravity = 8f;
	[Range(-1000f, -1f)] private float terminalVelocity = -1000f;
	private Vector3 velocity;

	// Found with GetComponent or Similar
	private PlayerInput playerInput;
	private CharacterController characterController;
	private Animator animator;

	// Set in Inspector
	[SerializeField] private Transform cameraTransform;

	public AudioSource jumpSound;
	public AudioSource runSound;
	public AudioSource jBoostSound;
	public AudioSource sBoostSound;

	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	// player will jump to the maximum height
	public void Jump(float heightToJump)
	{
		if (characterController.isGrounded)
		{
			jumpSound.Play();
			animator.SetTrigger("jump");
			gravityComponent = Mathf.Sqrt(-2f * -gravity * heightToJump);
		}
	}

	private void MovePlayer()
	{
		// movement physics set
		float moveInputMagnitude = playerInput.MoveInput.magnitude * speed;
		Vector3 direction = playerInput.MoveInput.normalized;
		direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;

		Vector3 finalVelocity = moveInputMagnitude * direction + (gravityComponent * Vector3.up);
		velocity = finalVelocity;

		characterController.Move(finalVelocity * Time.deltaTime);

		// for movement
		if (direction != Vector3.zero)
		{
			//runSound.Play();
			transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
			animator.SetFloat("movement", 1);
		}
		else
		{
			// idle
			animator.SetFloat("movement", 0);
		}
	}

	// for when the player is in air
	private void CalculateAnimations()
	{
		animator.SetBool("airborne", !characterController.isGrounded);
	}

	// for vertical movement
	private void CalculateVerticalSpeed()
	{
		if (!characterController.isGrounded)
		{
			if (gravityComponent > terminalVelocity)
			{
				gravityComponent -= gravity * Time.deltaTime;
			}
		}

		else if (playerInput.JumpInput)
		{
			Jump(jumpHeight);
		}
	}

	// doubles player's speed
	public float speedBoost()
    {
		sBoostSound.Play();
		speed *= 2;
		return speed;
    }

	// doubles player's jump height
	public float jumpBoost()
    {
		jBoostSound.Play();
		jumpHeight *= 2;
		return jumpHeight;
    }

	// Update is called once per frame
	void Update()
	{
		CalculateVerticalSpeed();
		CalculateAnimations();
		MovePlayer();
	}
}