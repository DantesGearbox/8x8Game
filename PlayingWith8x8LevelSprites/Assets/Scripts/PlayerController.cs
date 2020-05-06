using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SequenceTool;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;

	[Header("Exposed Values")]
	public FloatWrapper movespeed;
	public BoolWrapper takesInput;
	public BoolWrapper dodgerollDisable;
	public Vector3Wrapper lastNonzeroVelocity;

	[Header("Sequences")]
	public Sequence dodgeRoll;
	//public Sequence shoot;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		//Save the last non-zero velocity that isn't higher than movespeed
		if (rb.velocity.magnitude > 0)
		{
			lastNonzeroVelocity.vectorValue = rb.velocity;
			lastNonzeroVelocity.vectorValue = Vector2.ClampMagnitude(lastNonzeroVelocity.vectorValue, movespeed.floatValue);
		}

		//Return if we are not taking input currently
		if (!takesInput.boolValue)
		{
			return;
		}

		//Find movement for current frame
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(xInput, yInput).normalized;

		rb.velocity = direction * movespeed.floatValue;

		if (Input.GetKeyDown(KeyCode.LeftShift) && !dodgerollDisable.boolValue)
		{
			dodgeRoll.StartSequence();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//shoot.StartTimer();
		}
	}
}
