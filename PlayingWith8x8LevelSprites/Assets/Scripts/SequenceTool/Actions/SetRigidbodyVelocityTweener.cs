using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidbodyVelocityTweener : SequenceAction
{
	public Rigidbody2D rb;
	public Vector2 newVelocity;

	public override void StartTween()
	{
		rb.velocity = newVelocity;
	}

	public override void StopTween()
	{
		
	}
}
