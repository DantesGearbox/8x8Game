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
	public BoolWrapper inputEnabled;
	public BoolWrapper dodgerollEnabled;
	public BoolWrapper shootingEnabled;
	public Vector3Wrapper lastNonzeroVelocity;

	[Header("Sequences")]
	public Sequence dodgeRoll;
	public Sequence shoot;

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
		if (!inputEnabled)
		{
			return;
		}

		//Find movement for current frame
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(xInput, yInput).normalized;

		rb.velocity = direction * movespeed.floatValue;

		if (Input.GetKeyDown(KeyCode.LeftShift) && dodgerollEnabled)
		{
			dodgeRoll.StartSequence();
		}

		if (Input.GetKeyDown(KeyCode.Space) && shootingEnabled)
		{
			shoot.StartSequence();
		}
	}
}
