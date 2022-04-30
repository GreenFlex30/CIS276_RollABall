using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
	//Decide which to use - character controller

	// Variables
	[SerializeField] private float speed = 5f;
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

	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	// NOTE: only for pwr, NOT forcing to jump. method needs to change
	public void Jump(float heightToJump)
	{
		if (characterController.isGrounded)
		{
			animator.SetTrigger("Jump");
			gravityComponent = Mathf.Sqrt(-2f * -gravity * heightToJump);
		}
		//animator.SetTrigger("jump");
		//gravityComponent = Mathf.Sqrt(-2f * -gravity * heightToJump);
	}

	private void MovePlayer()
	{
		float moveInputMagnitude = playerInput.MoveInput.magnitude * speed;
		Vector3 direction = playerInput.MoveInput.normalized;
		direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;

		Vector3 finalVelocity = moveInputMagnitude * direction + (gravityComponent * Vector3.up);
		velocity = finalVelocity;

		characterController.Move(finalVelocity * Time.deltaTime);

		if (direction != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
			animator.SetFloat("MoveSpeed", 1);
		}
		else
		{
			animator.SetFloat("MoveSpeed", 0);
		}
	}

	private void CalculateAnimations()
	{
		/*
		function moved to Jump() method
		if(PlayerInput.JumpInput && characterController.isGrounded)
		{
			animator.SetTrigger("jump");
		}
		*/
		animator.SetBool("airborne", !characterController.isGrounded);
	}

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
			//gravityComponent = Mathf.Sqrt(-2f * -gravity * jumpHeight);
			Jump(jumpHeight);
		}
	}

	// Update is called once per frame
	void Update()
	{
		CalculateVerticalSpeed();
		MovePlayer();
	}
}