using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	//Input Constant Names
	public const string HORIZONTAL_INPUT = "Horizontal";
	private const string VERTICAL_INPUT = "Vertical";
	private const string CAMERA_HORIZONTAL_INPUT = "Mouse X";
	private const string CAMERA_VERTICAL_INPUT = "Mouse Y";
	private const string JUMP_INPUT = "Jump";
	//added
	private const string CLEAN_INPUT = "Fire1";

	// Variables
	public bool inputEnabled;

	// button inputs
	[field: SerializeField] public Vector3 MoveInput { get; private set; }
	[field: SerializeField] public bool JumpInput { get; private set; }
	[field: SerializeField] public Vector3 CameraMoveInput { get; private set; }
	//added
	[field: SerializeField] public static bool CleanInput { get; private set; }

	// sets the given inputs
	private void SetInputs()
	{
		MoveInput = new Vector3(Input.GetAxis(HORIZONTAL_INPUT), 0, Input.GetAxis(VERTICAL_INPUT));
		JumpInput = Input.GetButtonDown(JUMP_INPUT);
		CameraMoveInput = new Vector3(Input.GetAxis(CAMERA_HORIZONTAL_INPUT), Input.GetAxis(CAMERA_VERTICAL_INPUT));
		//added
		CleanInput = Input.GetButtonDown(CLEAN_INPUT);
	}

	// resets inputs when called
	private void ResetInputs()
	{
		MoveInput = Vector3.zero;
		CameraMoveInput = Vector3.zero;
		JumpInput = false;
		//added
		CleanInput = false;
	}

	// player is given control
	private void Start()
	{
		inputEnabled = true;
	}

	// input setter
	private void Update()
	{
		if (inputEnabled)
		{
			SetInputs();
		}
		else
		{
			ResetInputs();
		}
	}
}