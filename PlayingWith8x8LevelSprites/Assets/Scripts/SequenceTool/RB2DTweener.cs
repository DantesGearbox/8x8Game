using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB2DTweener : SequenceAction
{
	public Rigidbody2D rigidbody2DReference;

	public Vector3 startingValue;
	public Vector3 endValue;

	private bool isTweening = false;

	private void Update()
	{
		if (isTweening)
		{
			UpdatePosition();
			UpdateTimer();
		}
	}

	private void UpdatePosition()
	{
		float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
		Vector3 target = Vector3.Lerp(startingValue, endValue, normalizedTimer);
		rigidbody2DReference.MovePosition(target);
	}

	private void UpdateTimer()
	{
		tweenTimer += Time.deltaTime;

		if (tweenTimer > tweenDuration)
		{
			StopTween();
			SetStartValueToEndValue(); //Make sure the current value gets to the max, even with slight lerp errors
		}
	}

	private void SetStartValueToEndValue()
	{
		rigidbody2DReference.MovePosition(endValue);
	}

	public override void StartTween()
	{
		isTweening = true;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
	}
}
