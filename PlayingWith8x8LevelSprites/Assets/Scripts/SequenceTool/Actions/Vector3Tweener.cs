using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Tweener : SequenceAction
{
	public Vector3Wrapper vectorReference;

	public Vector3 startingValue;
	public Vector3 endValue;

	private bool isTweening = false;

	private void Update()
	{
		if (isTweening)
		{
			UpdateVector3();
			UpdateTimer();
		}
	}

	private void UpdateVector3()
	{
		float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
		vectorReference.vectorValue = Vector3.Lerp(startingValue, endValue, normalizedTimer);
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
		vectorReference.vectorValue = endValue;
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
