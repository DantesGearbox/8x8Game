using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB2DRelativeTweener : Tween
{
	public Rigidbody2D rigidbody2DReference;

	public bool useCurrentVelocityAsDirection = false;

	public float speed;
	public Vector2 direction;

	private Vector2 movementVector;

	private bool isTweening = false;

	private void Update()
	{
		if (isTweening)
		{
			UpdateTimer();
		}
	}

	private void UpdateTimer()
	{
		tweenTimer += Time.deltaTime;

		if (tweenTimer > tweenDuration)
		{
			StopTween();
		}
	}

	public override void StartTween()
	{
		isTweening = true;

		Vector2 moveDirection;
		if (useCurrentVelocityAsDirection)
		{
			moveDirection = rigidbody2DReference.velocity.normalized;
		}
		else
		{
			moveDirection = direction.normalized;
		}

		movementVector = moveDirection * speed;
		rigidbody2DReference.velocity += movementVector;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
		rigidbody2DReference.velocity -= movementVector;
	}
}
