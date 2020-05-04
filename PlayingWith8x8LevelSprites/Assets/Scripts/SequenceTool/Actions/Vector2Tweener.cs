using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Tweener : SequenceAction
{
	public Vector2 referencedVector;

	public Vector2 startingValue;
	public Vector2 endValue;

	private bool isTweening = false;

	private void Update()
	{
		if (isTweening)
		{
			UpdateVector2();
			UpdateTimer();
		}
	}

	private void UpdateVector2()
	{
		float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
		referencedVector = Vector2.Lerp(startingValue, endValue, normalizedTimer);
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
		referencedVector = endValue;
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
