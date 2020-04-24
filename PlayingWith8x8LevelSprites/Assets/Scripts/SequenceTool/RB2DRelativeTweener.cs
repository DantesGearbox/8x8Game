using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB2DRelativeTweener : Tween
{
	public Rigidbody2D rigidbody2DReference;
	public Vector3Wrapper vector3Reference;

	public bool useVectorRefAsDirection = false;
	public bool useReverseVector = false;

	public float speed;
	public Vector2 direction;

	public Vector2 movementVector;

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

		//Use the supplied vector as the movement direction
		Vector2 moveDirection = direction.normalized;
		if (useVectorRefAsDirection)
		{
			moveDirection = vector3Reference.vectorValue.normalized;
		}
		if (useReverseVector){
			moveDirection = (vector3Reference.vectorValue * -1.0f).normalized;
		}

		movementVector = moveDirection * speed;
		rigidbody2DReference.velocity = movementVector;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
		rigidbody2DReference.velocity = Vector2.zero;
	}
}
